Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

Class DynamicInvokeDll
    Public Shared Function Invoke(dll As String, name As String, parameters As Object(), returnType As Type) As Object
        Dim typeList As New List(Of Type)()
        For i As Integer = 0 To parameters.Length - 1
            typeList.Add(parameters(i).[GetType]())
        Next

        Dim A As AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(New AssemblyName("DynamicInvokeDll"), AssemblyBuilderAccess.Run)
        Dim M As ModuleBuilder = A.DefineDynamicModule("MB")
        Dim MB As MethodBuilder = M.DefinePInvokeMethod(name, dll, MethodAttributes.[Public] Or MethodAttributes.[Static] Or MethodAttributes.PinvokeImpl, CallingConventions.Standard, returnType, typeList.ToArray(),
            CallingConvention.Winapi, CharSet.Ansi)
        MB.SetImplementationFlags(MethodImplAttributes.PreserveSig)
        M.CreateGlobalFunctions()
        Dim x As MethodInfo = M.GetMethod(name)
        Return x.Invoke(Nothing, parameters)
    End Function


    Public Shared Sub InvokeParm(dll As String, name As String, ByRef parameters As Object(), returntype As Type)
        Dim typeList As New List(Of Type)()
        For i As Integer = 0 To parameters.Length - 1
            typeList.Add(parameters(i).[GetType]())
        Next

        Dim A As AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(New AssemblyName("DynamicInvokeDll"), AssemblyBuilderAccess.Run)
        Dim M As ModuleBuilder = A.DefineDynamicModule("MB")
        Dim MB As MethodBuilder = M.DefinePInvokeMethod(name, dll, MethodAttributes.[Public] Or MethodAttributes.[Static] Or MethodAttributes.PinvokeImpl, CallingConventions.Standard, returntype, typeList.ToArray(),
        CallingConvention.Winapi, CharSet.Ansi)
        MB.SetImplementationFlags(MethodImplAttributes.PreserveSig)
        M.CreateGlobalFunctions()
        Dim x As MethodInfo = M.GetMethod(name)
        Dim f = x.Invoke(Nothing, parameters)
        f = f
    End Sub

End Class