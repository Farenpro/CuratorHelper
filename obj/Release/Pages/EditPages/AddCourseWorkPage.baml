   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5    /CuratorHelper.Pages.EditPages.AddCourseWorkPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     6sys&clr-namespace:System;assembly=mscorlib     $	��430��$	��670��$	��670��$	��430��$��16(�(   "CuratorHelper.Properties.Resources    AddCourseWork N� Title# Z     FontMain N� 
FontFamily# [  .��� $��5q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto �.+��� #��Z   	 LHead#��[ �� $��1��   Student#��Z   LDescription#��[ �� -    ��Name$ CBoxStudents��$��2��$��
15,5,15,15q�$
��Left=�$	��300�� �� 
IsEditable .  �� IsTextSearchEnabled . 	 �� DisplayMemberPath$	 GroupAndFIO��
���   �
   RequiredFillIn)  #MaterialDesignThemes.Wpf.HintAssist   
HelperText# Z
  " MaterialDesignOutlinedComboBox#��[  �� SelectedItem �� *	Student+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWayToSource=��� $��3��   
Discipline#��Z #��[ �� -   $ CBoxDisciplines��$��4��$��
15,5,15,15q�$
��Left=�$	��300�� .  . $	 IndexAndName��
���   �# Z
 #��[  �� *
Discipline+$ PropertyChanged=�$ OneWayToSource=��� $��5��   
FinishDate#��Z #��[ (  "System.Windows.Controls.DatePicker  -     Name$ DPFinishDate��$��6��$��
15,5,15,15q�$
��Left=�$	��300��   FirstDayOfWeek$ Monday=�|�.     FinishDateToolTip � ToolTip# Z # Z
 
���   �*  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$ Light=� $  MaterialDesignOutlinedDatePicker#��[    SelectedDate �� *
FinishDate+$ PropertyChanged=�$ OneWayToSource=��� $��1��$��1��   Theme#��Z #��[ �� -    ��Name$ 	TBoxTheme��$��2��$��1��$��
15,5,15,15q�$
��Left=�$	��300��# Z
  �� 	MaxLength$ 50��
���   � ! MaterialDesignOutlinedTextBox#��[ ���� *Theme+$ PropertyChanged=��� $��3��$��1��   Term#��Z #��[ �� -   $ CBoxTerm��$��4��$��1��$��
15,5,15,15q�$
��Left=�$	��300�� .  . 
���   �# Z
 #��[  �� SelectedIndex$ 0�� �� SelectedValue �� *Term+$ PropertyChanged=�$ OneWayToSource=�����  �� Type" ��.s���1����2����3����4����5����6����7����8���� $��5��$��1��   Mark#��Z #��[ �� -   $ CBoxMark��$��6��$��1��$��
15,5,15,15q�$
��Left=�$	��300�� .  . 
���   �# Z
 #��[ $ 3�� �� *Mark+$ PropertyChanged=�$ OneWayToSource=����� " ��.s���2����3����4����5���� -    ��Name$ 	BtnCancel��$��7��$��5q�    Cancel#��Z   ! MaterialDesignFlatMidBgButton#��[ �� -   $ BtnAdd��$��7��$��1��$��5q�#��Z   * &MaterialDesignFlatSecondaryMidBgButton#��[ 