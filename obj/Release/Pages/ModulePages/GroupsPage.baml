   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  0    *CuratorHelper.Pages.ModulePages.GroupsPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��400��$��16(�(   "CuratorHelper.Properties.Resources    Groups N� Title# Z     FontMain N� 
FontFamily# [  .��� $��10q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+��� -    ��Name$ BtnAddGroup��$��5q�   AddGroup#��Z  * &MaterialDesignFlatSecondaryMidBgButton#��[ &   System.Windows.Controls.DataGrid  -     Name$ DGGroups��$
��auto��$��1��
�������
����  �   CanUserDeleteRows .     HeadersVisibility$ Column=�	   
IsReadOnly	 . 
 �� SelectedValuePath$
 ID��   AutoGenerateColumns .     CanUserAddRows .     SelectionUnit$ FullRow=�   SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto    Header$ Название��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $
 auto $  Специальность�� �� *SpecializationName+  $
 auto $ Отделение�� �� *DepartmentName+  $
 auto $$ Кол-во студентов�� �� *StudentCount+  $
 auto $ Куратор�� �� *CuratorName+4  .System.Windows.Controls.DataGridTemplateColumn  $
 auto $' !Изменить куратора��   CellTemplate �� .R��� $ BtnEditCurator��-   $
��auto��$��5q�   Edit#��Z #��[   $
 auto $3 -Изменить преподавателей�� �� .R��� $ BtnEditTeachers��-   $
��auto��$��5q�#��Z #��[   $
 auto $' !Вывести ведомость�� �� .R��� $ BtnOutputStatement��-   $
��auto��$��5q�   Output#��Z #��[    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"   �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  �� Property � ��  SecondaryHueMidBrush �� Value# �  �� -   $ BtnDeleteGroup��$��2��$
��auto��$��5q�   Delete#��Z 
���  ��#��[ 