using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.Utilities.CommonEnum
{
    public enum FormMode : int
    {
        Add = 1,
        Edit = 2,
        Browse = 3
    }

    public enum TransportSubModule : int
    {
        Booking = 1,
        Planning = 2,
        Marketing = 3
    }

    public enum Job_Status : int
    {
        UnConfirm = 0,
        Booked = 1,
        Cancelled = 2,
        Billed = 3,
        Completed = 4,
        Closed = 5,
        Reopened = 6
    }
    public enum Shipment_Status : int
    {
        Booked = 1,
        Ready = 2,
        Assigned = 3,
        Completed = 4,
        Invoiced = 5
    }
    public enum Trip_Status : int
    {
        SentOut = 0,
        Accepted = 1,
        Started = 2,
        Arrived_At_Pickup = 3,
        Waiting_For_Pickup = 4,
        Loading_Started = 5,
        Loading_Completed = 6,
        Going_To_Delivery = 7,
        Arrived_At_Delivery = 8,
        Waiting_For_Delivery = 9,
        UnLoading_Start = 10,
        Completed = 11,
        Cancelled = 99
    }
    public enum UOM_TYPE : int
    {
        Weight = 1,
        Volume = 2,
        Others = 3
    }
    public enum TruckMovementUOM_WtVol : int
    {
        KGM = 1,    //weight
        MT = 2,     //weight
        CBM = 3   //volume

    }
    public enum Trip_Type : int
    {
        OTO = 1, // one origin to one destination
        OTM = 2, // one origin to multiple destination
        MTO = 3  // many origin to one destination
    }
    public enum Job_Type : int
    {
        LO = 1,  //for local job
        SE = 21, //for sea export job
        SI = 22, //for sea import job
        AE = 31, //for air export job
        AI = 32, //for air import job
        CN = 4   //for Consignment Note
    }
    public enum JobUrgency_Type : int
    {
        Normal = 1,
        Important = 2,
        Urgent = 3
    }
    public enum Leg_Type : int
    {
        OneLeg = 1, //for one stop job
        TwoLegs = 2, //
        FirstOfTwoLeg = 21,
        SecondOfTwoLeg = 22,
        MoreThanTwoLegs = 3
    }
    public enum TIME_BOUND
    {
        NONE = 0, //no specific
        FIXED_PICKUP = 1, //specific time for pickup
        FIXED_DELIVERY = 2, //specific time for delivery
        AM_PICKUP = 3, //00:00:00 - 11:59:00 must pickup
        AM_DELIVERY = 4, //00:00:00 - 11:59:00 must deliver
        PM_PICKUP = 5, //12:00:00 - 23:59:59 must pickup
        PM_DELIVERY = 6 //12:00:00 - 23:59:59 must deliver
    }
 
    public enum Designation : int
    {
        Admin = 1,
        HR = 2,
        Office_Staff = 3,
        Company_Driver = 4,
        Truck_Driver = 5,
        Truck_Helper = 6,
        Truck_Maintenance = 7
    }
    public enum Employee_Status : int
    {
        Available = 1,
        Resigned = 2,
    }
    #region Messaging
    public enum MessageTripStatus : int
    {
        [DescriptionAttribute("O")]
        None, //appointment was not sent to driver, default message status for each appointments
        [DescriptionAttribute("N")]
        SentOut, //this is the status when planner sent instruction to the driver.
        [DescriptionAttribute("A")]
        Acknowledged, //(Optional) the driver will acknowledge when received the message 
        [DescriptionAttribute("JS")]
        JobStarted, //the trip is ongoing. 
        [DescriptionAttribute("AP")]
        Arrived_At_Pickup, //the arrived at pickup location
        [DescriptionAttribute("WP")]
        Waiting_Pickup, //driver need to wait sometimes before can do pickup example loading bay is full
        [DescriptionAttribute("LS")]
        Loading_Started, //driver already park in loading bay and start loading
        [DescriptionAttribute("LC")]
        Loading_Completed, //all shipments are already loaded to the vehicle and ready to deliver
        [DescriptionAttribute("SD")]
        Going_To_Delivery, //driver start delivery
        [DescriptionAttribute("AD")]
        Arrived_At_Delivery, //the arrived at delivery location
        [DescriptionAttribute("WD")]
        Waiting_Delivery, //driver need to wait sometimes before can do delivery example loading bay is full
        [DescriptionAttribute("S")]
        Completed, //complete unloading the shipment and the driver is ready for next job
        [DescriptionAttribute("C")]
        Cancelled, //the planner cancelled the trip instruction to driver
    }

    public enum MessageCodes : int
    {
        TI01 = 0, // trip instruction message
        TU01 = 1, // trip update message
        FTTI = 2, // free text message from planner, not job related
        FTTU = 3, // free text message from driver
        TC01 = 4 // cancel instruction message
    }

    public enum Msg_Job_Type : int
    {
        LCL = 1,
        FCL = 2,
        Parcel = 3
    }

    #endregion

}
