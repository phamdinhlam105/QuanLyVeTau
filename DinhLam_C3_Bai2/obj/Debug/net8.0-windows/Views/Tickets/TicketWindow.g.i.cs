﻿#pragma checksum "..\..\..\..\..\Views\Tickets\TicketWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FE2B72E30E67AA83D8F09FCEEE7232113D3C6254"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DinhLam_C3_Bai2.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DinhLam_C3_Bai2.Views {
    
    
    /// <summary>
    /// TicketWindow
    /// </summary>
    public partial class TicketWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel buttonPanel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btNewTicket;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btTicketDetail;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSchedule;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel mainPanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DinhLam_C3_Bai2;V1.0.0.0;component/views/tickets/ticketwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.buttonPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.btNewTicket = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
            this.btNewTicket.Click += new System.Windows.RoutedEventHandler(this.NewTicket_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btTicketDetail = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
            this.btTicketDetail.Click += new System.Windows.RoutedEventHandler(this.TicketDetail_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btSchedule = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
            this.btSchedule.Click += new System.Windows.RoutedEventHandler(this.Schedule_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 63 "..\..\..\..\..\Views\Tickets\TicketWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Quit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.mainPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

