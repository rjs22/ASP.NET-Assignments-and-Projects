using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

/// <summary>
/// EventDAO class is the main class which interacts with the database. SQL Server express edition
/// has been used.
/// the event information is stored in a table named 'event' in the database.
///
/// Here is the table format:
/// event(event_id int, title varchar(100), description varchar(200),event_start datetime, event_end datetime)
/// event_id is the primary key
/// </summary>
public class EventDAO
{
	//change the connection string as per your database connection.
    //private static string connectionString = ConfigurationManager.AppSettings["DBConnString"];

	//this method retrieves all events within range start-end
    public static List<CalendarEvent> getEvents(DateTime start, DateTime end)
    {
        

        using (DBContextDataContext db = new DBContextDataContext())
        {
            List<CalendarEvent> events = new List<CalendarEvent>();
            var qry = (from x in db.Appointments where x.AppointmentDate >= start && x.AppointmentComplete <= end select x).ToList();

            foreach (var time in qry)
            {
                events.Add(new CalendarEvent()
                {
                    id = Convert.ToInt32(time.AppointmentID),
                    description = Convert.ToString(time.AppointmentDescription),
                    start = Convert.ToDateTime(time.AppointmentDate),
                    end = Convert.ToDateTime(time.AppointmentComplete)
                });
            }

            return events;
        }
        
        //side note: if you want to show events only related to particular users,
        //if user id of that user is stored in session as Session["userid"]
        //the event table also contains an extra field named 'user_id' to mark the event for that particular user
        //then you can modify the SQL as:
        //SELECT event_id, description, title, event_start, event_end FROM event where user_id=@user_id AND event_start>=@start AND event_end<=@end
        //then add paramter as:cmd.Parameters.AddWithValue("@user_id", HttpContext.Current.Session["userid"]);
    }

	//this method updates the event title and description
    public static void updateEvent(int id, String description)
    {
        using (DBContextDataContext db = new DBContextDataContext())
        {
            var qry = (from x in db.Appointments where x.AppointmentID == id select x).FirstOrDefault();

            qry.AppointmentID = id;
            qry.AppointmentDescription = description;

            db.SubmitChanges();
        }
    }

	//this method updates the event start and end time ... allDay parameter added for FullCalendar 2.x
    public static void updateEventTime(int id, DateTime start, DateTime end)
    {
        using (DBContextDataContext db = new DBContextDataContext())
        {
            var qry = (from x in db.Appointments where x.AppointmentID == id select x).FirstOrDefault();

            qry.AppointmentID = id;
            qry.AppointmentDate = start;
            qry.AppointmentComplete = end;

            db.SubmitChanges();
        }
    }

	//this mehtod deletes event with the id passed in.
    public static void deleteEvent(int id)
    {
        using (DBContextDataContext db = new DBContextDataContext())
        {
            var delete = (from x in db.Appointments where x.AppointmentID == id select x).FirstOrDefault();

            db.Appointments.DeleteOnSubmit(delete);
            db.SubmitChanges();
        }
    }

	//this method adds events to the database
    public static int addEvent(CalendarEvent cevent)
    {
        //add event to the database and return the primary key of the added event row

        //insert

        Appointment app = new Appointment
        {
            AppointmentDate = cevent.start,
            AppointmentComplete = cevent.end,
            AppointmentDescription = cevent.description
        };

        using (DBContextDataContext db = new DBContextDataContext())
        {
            db.Appointments.InsertOnSubmit(app);
            db.SubmitChanges();
        }

            int key = 0;

        using (DBContextDataContext db = new DBContextDataContext())
        {

            var first = (from x 
                       in db.Appointments
                       where x.AppointmentDescription == cevent.description && 
                       x.AppointmentDate == cevent.start && 
                       x.AppointmentComplete == cevent.end
                       select x.AppointmentID).Max();

            key = Convert.ToInt32(first);

            return key;
        }
        

        
    }
}
