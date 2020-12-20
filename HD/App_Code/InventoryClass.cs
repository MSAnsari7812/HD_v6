using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InventoryClass
/// </summary>
public class InventoryClass:CMSDAL.MsgClass
{

    public string InvID { get; set; }
    public string BuildingName { get; set; }
    public string Room { get; set; }
    public string Product { get; set; }
    public string Model{ get; set; }
    public string SerialNo { get; set; }
    public string Status { get; set; }
    public string Problem { get; set; }
    public string ErrorMessage { get; set; }
}