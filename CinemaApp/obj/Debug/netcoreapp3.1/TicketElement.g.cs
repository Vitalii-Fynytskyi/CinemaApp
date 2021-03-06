﻿#pragma checksum "..\..\..\TicketElement.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CE0114518DF10A640395595A3B7CB31582362366"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CinemaApp;
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


namespace CinemaApp {
    
    
    /// <summary>
    /// TicketElement
    /// </summary>
    public partial class TicketElement : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\TicketElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel OuterStackPanel;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\TicketElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTicketName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\TicketElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemMarkSold;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\TicketElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemMarkBooked;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\TicketElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemDemarkBooked;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CinemaApp;component/ticketelement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TicketElement.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.OuterStackPanel = ((System.Windows.Controls.StackPanel)(target));
            
            #line 9 "..\..\..\TicketElement.xaml"
            this.OuterStackPanel.MouseEnter += new System.Windows.Input.MouseEventHandler(this.OuterStackPanel_MouseEnter);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\TicketElement.xaml"
            this.OuterStackPanel.MouseLeave += new System.Windows.Input.MouseEventHandler(this.OuterStackPanel_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LabelTicketName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.MenuItemMarkSold = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\..\TicketElement.xaml"
            this.MenuItemMarkSold.Click += new System.Windows.RoutedEventHandler(this.MarkSold_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MenuItemMarkBooked = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\..\TicketElement.xaml"
            this.MenuItemMarkBooked.Click += new System.Windows.RoutedEventHandler(this.MarkBooked_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MenuItemDemarkBooked = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\..\TicketElement.xaml"
            this.MenuItemDemarkBooked.Click += new System.Windows.RoutedEventHandler(this.DemarkBooked_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

