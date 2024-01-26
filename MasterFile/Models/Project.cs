using Humanizer;
using MasterFile.Models.Base;
using MasterFile.Models.Enum;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Drawing;

namespace MasterFile.Models
{
    public class Project : BaseEntity
    {
        public string district { get; set; }
        public string Coordinate { get; set; }
        public string Address { get; set; }
        public string TSno { get; set; }
        public string AddressOpticalCable { get; set; }
        public string ConnectionPointElectricalCable { get; set; }
        public string BCGroupNote { get; set; }
        public string AVİCOMNote { get; set; }
        public int PTZCameraCount { get; set; }
        public int FİXCameraCount { get; set; }
        public int CapturedCameraCount { get; set; }
        public int CapturedNotCameraCount { get; set; }
        public int ActualInstalledCameraCount { get; set; }

        public bool SwitchModel { get; set; }

        public DateTime ViewHistory { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ExploitationHistory { get; set; }
        public DateTime DateFirstImage { get; set; }


        public PoleType PoleType { get; set; }
        public Concluded ImageAcceptance { get; set; }
        public Concluded CommissioningAddingToGenetek { get; set; }
        public WorkInProgress Foundation { get; set; }
        public ConnectionType ConnectionType { get; set; }
        public WorkInProgress PoleInstallation { get; set; }
        public WorkInProgress OpticalShooting { get; set; }
        public WorkInProgress OpticalFinish { get; set; }
        public WorkInProgress ElectricalWiring { get; set; }
        public WorkInProgress FinalStatusBCGOperations { get; set; }
        public WorkInProgress HandedOverAvicom { get; set; }
        public WorkInProgress AntennaInstallation { get; set; }
        public WorkInProgress BoxInstallation { get; set; }
        public WorkInProgress InstallationCamera { get; set; }
        public WorkInProgress FirstImageAcquisition { get; set; }
    }
}
