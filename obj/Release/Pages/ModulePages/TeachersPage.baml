   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  2    ,CuratorHelper.Pages.ModulePages.TeachersPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��390��$��16(�(   "CuratorHelper.Properties.Resources    Teachers N� Title# Z     FontMain N� 
FontFamily# [  .��� $��10q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+��� -    ��Name$ BtnAddTeacher��$��5q�   
AddTeacher#��Z  * &MaterialDesignFlatSecondaryMidBgButton#��[ &   System.Windows.Controls.DataGrid  -     Name$ 
DGTeachers��$��1��
�������$
��auto��
����  �   CanUserDeleteRows .     
IsReadOnly . 	 �� SelectedValuePath$	 ID��
   AutoGenerateColumns
 .     CanUserAddRows .     SelectionUnit$ FullRow=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto    Header$ ФИО��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *FIO+  $
 auto $ Пол�� �� *
GenderName+4  .System.Windows.Controls.DataGridTemplateColumn  $
 auto $B <Изменить преподаваемые предметы��   CellTemplate �� .R��� $ BtnEditTeachObjects��-   $��5q�   Edit#��Z #��[    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"   �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  �� Property � ��  SecondaryHueMidBrush �� Value# �  �� -   $ BtnDeleteTeacher��$��2��$
��auto��$��5q�   Delete#��Z 
���  ��#��[ 