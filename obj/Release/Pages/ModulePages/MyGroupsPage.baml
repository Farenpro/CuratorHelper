   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  2    ,CuratorHelper.Pages.ModulePages.MyGroupsPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��400��$��16(�(   "CuratorHelper.Properties.Resources    Groups N� Title# Z     FontMain N� 
FontFamily# [  .��� $��10q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+���    	GroupName#��Z  	 LHead#��[ �� -    ��Name$ CBoxMyGroups��$��1��$��5q�$
��Left=�$
��auto�� �� 
IsEditable .  �� IsTextSearchEnabled .  �� DisplayMemberPath$
 Name��
���   � " MaterialDesignOutlinedComboBox#��[ &   System.Windows.Controls.DataGrid  -   	  Name$	 DGMyGroupsStudents��$
��auto��$��2��
�������
����  �
   CanUserDeleteRows
 .     HeadersVisibility$ Column=�   
IsReadOnly .  �� SelectedValuePath$ ID��   AutoGenerateColumns .     CanUserAddRows .     SelectionUnit$ FullRow=�   SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto    Header$ ФИО Студента��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *FIO+  $
 auto $ Группа�� �� *	GroupName+4  .System.Windows.Controls.DataGridTemplateColumn  $
 auto $ Информация��   CellTemplate �� .R���  ��Name$ BtnStudentInfoEdit��-   $
��auto��$��5q�   Edit#��Z  * &MaterialDesignFlatSecondaryMidBgButton#��[   $
 auto $ Оценки�� �� .R��� $ BtnStudentMarks��-   $
��auto��$��5q�#��Z #��[   $
 auto $ Пропуски�� �� .R��� $ BtnStudentOmissions��-   $
��auto��$��5q�#��Z #��[   $
 auto $. (Взыскания и поощрения�� �� .R��� $ BtnStudentPenAndInc��-   $
��auto��$��5q�#��Z #��[   $
 auto $# Личная карточка�� �� .R��� $ BtnStudentPerCard��-   $
��auto��$��5q�   Form#��Z #��[    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"   �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  �� Property � ��  SecondaryHueMidBrush  �� Value#  �  