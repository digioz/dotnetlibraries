﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.2032
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=1.1.4322.2032.
'
Namespace Yahoo.API.LocalSearchResponse
    
    '<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:yahoo:lcl"),  _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="urn:yahoo:lcl", IsNullable:=false)>  _
    Public Class ResultSet
        
        '<remarks/>
        Public ResultSetMapUrl As String
        
        '<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Result")>  _
        Public Result() As ResultType
        
        '<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="integer")>  _
        Public totalResultsAvailable As String
        
        '<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="integer")>  _
        Public totalResultsReturned As String
        
        '<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="integer")>  _
        Public firstResultPosition As String
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:yahoo:lcl")>  _
    Public Class ResultType
        
        '<remarks/>
        Public Title As String
        
        '<remarks/>
        Public Address As String
        
        '<remarks/>
        Public City As String
        
        '<remarks/>
        Public State As String
        
        '<remarks/>
        Public Phone As String
        
        '<remarks/>
        Public Rating As String
        
        '<remarks/>
        Public Distance As DistanceType
        
        '<remarks/>
        Public Url As String
        
        '<remarks/>
        Public ClickUrl As String
        
        '<remarks/>
        Public MapUrl As String
        
        '<remarks/>
        Public BusinessUrl As String
        
        '<remarks/>
        Public BusinessClickUrl As String
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:yahoo:lcl")>  _
    Public Class DistanceType
        
        '<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(),  _
         System.ComponentModel.DefaultValueAttribute(DistanceMeasureType.miles)>  _
        Public unit As DistanceMeasureType = DistanceMeasureType.miles
        
        '<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>  _
        Public Value As String
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:yahoo:lcl")>  _
    Public Enum DistanceMeasureType
        
        '<remarks/>
        miles
    End Enum
End Namespace
