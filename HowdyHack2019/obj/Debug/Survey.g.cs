﻿#pragma checksum "..\..\Survey.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "49DC744BD3320320F433223D7761F039BD33D54ADD797849FBB38B445C843940"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HowdyHack2019;
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


namespace HowdyHack2019 {
    
    
    /// <summary>
    /// Survey
    /// </summary>
    public partial class Survey : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Survey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox gradeComboBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Survey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox languageComboBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Survey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider years;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Survey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox teachComboBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Survey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox learnComboBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Survey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmit;
        
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
            System.Uri resourceLocater = new System.Uri("/HowdyHack2019;component/survey.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Survey.xaml"
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
            this.gradeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\Survey.xaml"
            this.gradeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.GradeComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.languageComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\Survey.xaml"
            this.languageComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LanguageComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.years = ((System.Windows.Controls.Slider)(target));
            
            #line 39 "..\..\Survey.xaml"
            this.years.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Years_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.teachComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 44 "..\..\Survey.xaml"
            this.teachComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TeachComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.learnComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 52 "..\..\Survey.xaml"
            this.learnComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LearnComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\Survey.xaml"
            this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.BtnSubmit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

