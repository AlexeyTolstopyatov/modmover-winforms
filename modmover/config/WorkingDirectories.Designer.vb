﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Этот код создан программой.
'     Исполняемая версия:4.0.30319.42000
'
'     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
'     повторной генерации кода.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.6.0.0")>  _
    Partial Friend NotInheritable Class WorkingDirectories
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As WorkingDirectories = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New WorkingDirectories()),WorkingDirectories)
        
        Public Shared ReadOnly Property [Default]() As WorkingDirectories
            Get
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("D:\Program Files\Tlauncher\legacy\Minecraft\game\mods")>  _
        Public Property MinecraftDirectory() As String
            Get
                Return CType(Me("MinecraftDirectory"),String)
            End Get
            Set
                Me("MinecraftDirectory") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("D:\mod")>  _
        Public Property CommonDirectory() As String
            Get
                Return CType(Me("CommonDirectory"),String)
            End Get
            Set
                Me("CommonDirectory") = value
            End Set
        End Property
    End Class
End Namespace
