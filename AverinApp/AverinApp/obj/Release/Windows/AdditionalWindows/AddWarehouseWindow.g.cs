﻿#pragma checksum "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F813DDE0A38237097DCC3F0BF40C178EF1DD705F1BFE0FCDC2E7CC209EFB7CCF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AverinApp.Windows.AdditionalWindows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace AverinApp.Windows.AdditionalWindows {
    
    
    /// <summary>
    /// AddWarehouseWindow
    /// </summary>
    public partial class AddWarehouseWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbxName;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbxAdress;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbxCapacity;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbxOperator;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSave;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AverinApp;component/windows/additionalwindows/addwarehousewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TbxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TbxAdress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TbxCapacity = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
            this.TbxCapacity.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TbxCapacity_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CbxOperator = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.BtnSave = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
            this.BtnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Windows\AdditionalWindows\AddWarehouseWindow.xaml"
            this.BtnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

