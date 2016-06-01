using System;
using Core.Model;

namespace InputControl.Model
{
    public class ControlledItem : BaseEntity, IItem
    {
        public string Designation { get; set; }
        public string Name { get; set; }
        public string ControlledItemInfo { get; set; }
        public string Params { get; set; }
        public string ControlType { get; set; }
        public string MeasurementTools { get; set; }
        public string Technique { get; set; }
        public string Label { get; set; }
        public string StorageTime { get; set; }
        public DateTime Date { get; set; }
        public string EditUserLogin { get; set; }
        public string Responsible { get; set; }
        public bool VpNeed { get; set; }
        public string SupportDocument { get; set; }


        // Nav props
        public virtual ItemToken Token { get; set; }
        public virtual ControlledSection ControlledSection { get; set; }
        public virtual Subdivision Subdiv { get; set; }
    }
}