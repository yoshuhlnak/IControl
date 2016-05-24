using InputControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InputControl.ViewModel
{
    public class ControlledItemViewModel
    {
        private readonly IList<BaseEntity> _entities;

        public ControlledItemViewModel(IList<BaseEntity> entities)
        {
            _entities = entities;
        }

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

        public void Cancel()
        {
        }

        public void Save()
        {
            foreach (var entity in _entities.OfType<FreeItem>() )
            {
                SaveEntity(entity);
            }
            foreach(var entity in _entities.OfType<ControlledItem>())
            {
                SaveEntity(entity);
            }
        }

        public void SaveEntity(FreeItem item)
        {
        }

        public void SaveEntity(ControlledItem item )
        {

        }
    }
}
