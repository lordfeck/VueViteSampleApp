using System.ComponentModel.DataAnnotations;

namespace VueViteSampleApp.Globals
{
     public static class Enums
     {
          public enum MessageStatus
          {
               Unread,
               Read,
               Deleted,
               Archived
          }

          public enum MessageOrigin
          {
               Practitioner,
               Client
          }

          public enum RecordVisibility
          {
               ClientAndPrac, PracOnly, None
          }
     
          public enum TreatmentRequestability
          {
               ClientAndPrac = 2, PracOnly = 1, None = 0
          }

          public enum Day
          {
               Monday = 0, Tuesday = 1, Wednesday = 2, Thursday = 3, Friday = 4, Saturday = 5, Sunday = 6
          }

          public enum TimeslotAvailability
          {
               Unavailable, Available
          }

          public enum AvailabilityEntity
          {
               Practitioner, Room
          }

          public enum AppointmentStatus
          {
               Live, 
               [Display(Name = "Cancelled by client")]
               CancelledByClient, 
               [Display(Name = "Cancelled by practitioner")]
               CancelledByPractitioner
          }
     
          public enum Title
          {
               Dr, Mr, Mrs, Miss, Ms, Lord, Cpl, Pope, Rev, RtHon
          }

          public enum Sex
          {
               Male, Female, Other, NotSpecified, YesPlease
          }
    
          public enum LicenceStatus
          {
               Trial,
               Active,
               Suspended
          }

          public enum ReservationStatus
          {
               Requested,
               Approved,
               Denied,
               CancelledByPractitioner,
               CancelledByClinic,
               Booked
          }

     }
}