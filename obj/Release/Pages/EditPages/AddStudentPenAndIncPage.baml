   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  ;    5CuratorHelper.Pages.EditPages.AddStudentPenAndIncPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��450��$	��400��$	��400��$	��450��$��16(�(   "CuratorHelper.Properties.Resources    AddStudentPenAndInc N� Title# Z     FontMain N� 
FontFamily# [  .��� $��5q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� #��Z    LDescription#��[ �� -    ��Name$ LStudentName��$��1��#��[ �� $��2��   Type#��Z #��[ �� -    ��Name$ CBoxPenAndIncType��$��3��$��
15,5,15,15q�$
��Left=�$	��300�� �� 
IsEditable .  �� IsTextSearchEnabled . 	 �� DisplayMemberPath$
	 Name��
���   �
   RequiredFillIn)  #MaterialDesignThemes.Wpf.HintAssist   
HelperText# Z
  " MaterialDesignOutlinedComboBox#��[  �� SelectedItem �� *PenAndIncType+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWayToSource=��� $��4��   Nature#��Z #��[ �� -    ��Name$ 
TBoxNature��$��5��$��
15,5,15,15q�$	��300��$
��Left=�$	��300��# Z
  �� 	MaxLength$	 100��
���   � ! MaterialDesignOutlinedTextBox#��[ ���� *Nature+$ PropertyChanged=��� $��6��   Order#��Z #��[ �� -   $ 	CBoxOrder��$��7��$��
15,5,15,15q�$
��Left=�$	��300�� .  . $	 FullInfo��
���   �# Z
 #��[  �� *Order+$ PropertyChanged=�$ OneWayToSource=��� $��8�� �� Orientation$ 
Horizontal=�$��5q�.+��� -    ��Name$ 	BtnCancel��$��5q�   Cancel#��Z  ! MaterialDesignFlatMidBgButton#��[ �� -   $ BtnAdd��$��5q�
   Add#��Z  * &MaterialDesignFlatSecondaryMidBgButton#��[ 