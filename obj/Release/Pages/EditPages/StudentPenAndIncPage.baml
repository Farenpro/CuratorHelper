   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  8    2CuratorHelper.Pages.EditPages.StudentPenAndIncPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��340��$	��400��$	��400��$	��340��$��16(�(   "CuratorHelper.Properties.Resources    StudentPenAndInc N� Title# Z     FontMain N� 
FontFamily# [  .��� $��10q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -    ��Name$ LStudentName��  LDescription#��[ �� -    ��Name$ BtnAddPenAndInc��$��1��$��5q�   AddStudentPenAndInc#��Z  * &MaterialDesignFlatSecondaryMidBgButton#��[ &   System.Windows.Controls.DataGrid  -     Name$ DGPenAndIncs��$
��auto��$��2��
�������
����  �   CanUserDeleteRows .  	   HeadersVisibility$	 Column=�
   
IsReadOnly
 .  �� SelectedValuePath$ ID��   AutoGenerateColumns .     CanUserAddRows .     SelectionUnit$ FullRow=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto    Header$ Тип��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
TypeName+  $
 auto $ Характер�� �� *Nature+  $
 auto $$ № и дата приказа�� �� *	OrderInfo+   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"   �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  �� Property � ��  SecondaryHueMidBrush �� Value# �  �� -   $ BtnDeletePenAndIncs��$��3��$
��auto��$��0,0,0,30q�   Delete#��Z 
���  ��#��[ 