   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  2    ,CuratorHelper.Pages.EditPages.AddTeacherPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��570��$	��360��$	��360��$	��570��$��16(�(   "CuratorHelper.Properties.Resources    
AddTeacher N� Title# Z     FontMain N� 
FontFamily# [  .��� $��5q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� #��Z   	 LHead#��[ �� $��1��   Surname#��Z   LDescription#��[ �� -    ��Name$ TBoxSurname��$��2��$��	10,0,0,20q�$
��Left=�$	��300��   RequiredFillIn)  #MaterialDesignThemes.Wpf.HintAssist   
HelperText# Z  �� 	MaxLength$ 50��
���   � ! MaterialDesignOutlinedTextBox#��[ ���� *	Surname+	 �� UpdateSourceTrigger$	 PropertyChanged=��� $��3��
   	Firstname#��Z
 #��[ �� -   $ TBoxFirstname��$��4��$��	10,0,0,20q�$
��Left=�$	��300��# Z $ 30��
���   �#��[ ���� *	Firstname+$	 PropertyChanged=��� $��5��   
Middlename#��Z #��[ �� -   $ TBoxMiddlename��$��6��$��	10,0,0,20q�$
��Left=�$	��300��$ 60��
���   �#��[ ���� *
Middlename+$	 PropertyChanged=��� $��7��   Gender#��Z #��[ �� -    ��Name$ 
CBoxGender��$��8��$��
15,5,15,15q�$
��Left=�$	��300�� �� 
IsEditable .  �� IsTextSearchEnabled .  �� DisplayMemberPath$
 Name��
���   �# Z  " MaterialDesignOutlinedComboBox#��[  �� SelectedItem �� *Gender+$	 PropertyChanged=� �� Mode$ OneWayToSource=��� $��9�� �� Orientation$ 
Horizontal=�$��5q�.+��� -    ��Name$ 	BtnCancel��$��5q�   Cancel#��Z  ! MaterialDesignFlatMidBgButton#��[ �� -   $ BtnAdd��$��5q�#��Z   * &MaterialDesignFlatSecondaryMidBgButton#��[ 