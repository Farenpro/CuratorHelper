   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  3    -CuratorHelper.Pages.EditPages.TeacherEditPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��270��$	��450��$	��450��$	��270��$��16(�(   "CuratorHelper.Properties.Resources    EditTeacherObjects N� Title# Z     FontMain N� 
FontFamily# [  .��(� .��� $��20q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� #��Z   	 LHead#��[ �� $��1��  LDescription#��[ ���� *TeacherName+��  �� Orientation$ 
Horizontal=�$��2��.+��� -    ��Name$ 
CBoxObject��$��
10,5,15,15q�$
��Left=�$	��300�� �� 
IsEditable .  �� IsTextSearchEnabled .  �� DisplayMemberPath$
 Name��
���   �	   RequiredFillIn)  #MaterialDesignThemes.Wpf.HintAssist
   
HelperText#
 Z	  " MaterialDesignOutlinedComboBox#��[   SecondaryHueMidBrush#���   �� SelectedItem �� *Object+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWayToSource=��� -    ��Name$ BtnAdd��$��5q�
   Add#��Z  * &MaterialDesignFlatSecondaryMidBgButton#��[ &   System.Windows.Controls.DataGrid  -     Name$ DGTeacherObjects��$��3��
�������#���     HeadersVisibility$
 None=�   AutoGenerateColumns .     CanUserAddRows .     SelectionUnit$ FullRow=�   CanUserDeleteRows .     
IsReadOnly . 
���   �$��1q�$��0,0,20,0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto    Header$' !Название предмета��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ObjectName+   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"   �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���   �� Property  � ��  PrimaryHueMidBrush! �� Value#! �  �� -   $ 	BtnDelete��$��4��$
��Left=�$��5q�"   Delete#��Z" 
���  �� ! MaterialDesignFlatMidBgButton#��[ 