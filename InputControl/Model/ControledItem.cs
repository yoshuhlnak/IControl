using System;

namespace InputControl.Model
{
    public class ControledItem : BaseEntity
    {
        public string Item { get; set; }
        public string Name { get; set; }
        public string ControlledItemInfo { get; set; }
        public string Params { get; set; }
        public string ControlType { get; set; }
        public string MeasurementTools { get; set; }
        public string Technique { get; set; }
        public string Label { get; set; }
        public string StorageTime { get; set; }
        public int Subdiv { get; set; }
        public DateTime Date { get; set; }
        public string EdituserLogin { get; set; }
        public string Responsible { get; set; }
        public int Section { get; set; }
        public bool VpNeed { get; set; }
        public string SupportDocument { get; set; }
        public int Token { get; set; }
    }
}