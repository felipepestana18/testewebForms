﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:4.0.30319.42000
'
'     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
'     o código for gerado novamente.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace ServiceReference1
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ServiceReference1.webservicesSoap")>  _
    Public Interface webservicesSoap
        
        'CODEGEN: Gerando contrato de mensagem porque o nome do elemento HelloWorldResult no namespace http://tempuri.org/ não está marcado como nulo
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/HelloWorld", ReplyAction:="*")>  _
        Function HelloWorld(ByVal request As ServiceReference1.HelloWorldRequest) As ServiceReference1.HelloWorldResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/HelloWorld", ReplyAction:="*")>  _
        Function HelloWorldAsync(ByVal request As ServiceReference1.HelloWorldRequest) As System.Threading.Tasks.Task(Of ServiceReference1.HelloWorldResponse)
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class HelloWorldRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="HelloWorld", [Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public Body As ServiceReference1.HelloWorldRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As ServiceReference1.HelloWorldRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute()>  _
    Partial Public Class HelloWorldRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class HelloWorldResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="HelloWorldResponse", [Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public Body As ServiceReference1.HelloWorldResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As ServiceReference1.HelloWorldResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class HelloWorldResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public HelloWorldResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal HelloWorldResult As String)
            MyBase.New
            Me.HelloWorldResult = HelloWorldResult
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface webservicesSoapChannel
        Inherits ServiceReference1.webservicesSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class webservicesSoapClient
        Inherits System.ServiceModel.ClientBase(Of ServiceReference1.webservicesSoap)
        Implements ServiceReference1.webservicesSoap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function ServiceReference1_webservicesSoap_HelloWorld(ByVal request As ServiceReference1.HelloWorldRequest) As ServiceReference1.HelloWorldResponse Implements ServiceReference1.webservicesSoap.HelloWorld
            Return MyBase.Channel.HelloWorld(request)
        End Function
        
        Public Function HelloWorld() As String
            Dim inValue As ServiceReference1.HelloWorldRequest = New ServiceReference1.HelloWorldRequest()
            inValue.Body = New ServiceReference1.HelloWorldRequestBody()
            Dim retVal As ServiceReference1.HelloWorldResponse = CType(Me,ServiceReference1.webservicesSoap).HelloWorld(inValue)
            Return retVal.Body.HelloWorldResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function ServiceReference1_webservicesSoap_HelloWorldAsync(ByVal request As ServiceReference1.HelloWorldRequest) As System.Threading.Tasks.Task(Of ServiceReference1.HelloWorldResponse) Implements ServiceReference1.webservicesSoap.HelloWorldAsync
            Return MyBase.Channel.HelloWorldAsync(request)
        End Function
        
        Public Function HelloWorldAsync() As System.Threading.Tasks.Task(Of ServiceReference1.HelloWorldResponse)
            Dim inValue As ServiceReference1.HelloWorldRequest = New ServiceReference1.HelloWorldRequest()
            inValue.Body = New ServiceReference1.HelloWorldRequestBody()
            Return CType(Me,ServiceReference1.webservicesSoap).HelloWorldAsync(inValue)
        End Function
    End Class
End Namespace