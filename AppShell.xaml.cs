﻿using ABFReportEditor.Views;
using ABFReportEditor.Views.FinalViews;
using ABFReportEditor.Views.InfoViews;
using ABFReportEditor.Views.TestViews;

namespace ABFReportEditor;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        // Register InfoViews
        Routing.RegisterRoute("CustomerInfo", typeof(CustomerInfoPage));
        Routing.RegisterRoute("DeviceInfo", typeof(DeviceInfoPage));
        
        // Register TestViews
        Routing.RegisterRoute("RpTest", typeof(RpTestPage));
        Routing.RegisterRoute("DcTest", typeof(DcTestPage));
        Routing.RegisterRoute("PvbTest", typeof(PvbTestPage));
        
        // Register FinalViews
        Routing.RegisterRoute("PassFinal", typeof(PassFinalView));
    }
}