   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 3    -CuratorHelper.Pages.EditPages.CreateOrderPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     6sys&clr-namespace:System;assembly=mscorlib     $	��430��$	��360��$	��360��$	��430��$��16(�(   "CuratorHelper.Properties.Resources    CreateOrder N� Title# Z     FontMain N� 
FontFamily# [  .��� $��5q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� #��Z   	 LHead#��[ �� $��1��   Student#��Z   LDescription#��[ �� -    ��Name$ CBoxStudents��$��2��$��
15,5,15,15q�$
��Left=�$	��300�� �� 
IsEditable .  �� IsTextSearchEnabled .  �� DisplayMemberPath$ GroupAndFIO��
���   �	   RequiredFillIn)  #MaterialDesignThemes.Wpf.HintAssist
   
HelperText#
 Z	  " MaterialDesignOutlinedComboBox#��[  �� SelectedItem �� *	Student+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWayToSource=��� $��3��   	OrderType#��Z #��[ �� -   $ CBoxOrderTypes��$��4��$��
15,5,15,15q�$
��Left=�$	��300�� .  . $
 Name��
���   �#
 Z	 #��[  �� *	OrderType+$ PropertyChanged=�$ OneWayToSource=��� $��5��   Course#��Z #��[ �� -   $ 
CBoxCourse��$��6��$��
15,5,15,15q�$
��Left=�$	��300�� .  . 
���   �#��[  �� SelectedValue �� *Course+$ PropertyChanged=�$ OneWayToSource=�����  �� Type" ��.s���1����2����3����4���� $��7�� �� Orientation$ 
Horizontal=�$��5q�.+��� -    ��Name$ 	BtnCancel��$��5q�   Cancel#��Z  ! MaterialDesignFlatMidBgButton#��[ �� -   $ 	BtnCreate��$��5q�#��Z   * &MaterialDesignFlatSecondaryMidBgButton#��[ 