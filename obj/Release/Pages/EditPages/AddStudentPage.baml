   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  2    ,CuratorHelper.Pages.EditPages.AddStudentPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��450��$	��660��$	��660��$	��450��$��16(�(   "CuratorHelper.Properties.Resources    
AddStudent N� Title# Z     FontMain N� 
FontFamily# [  .��� $��5q� � ColumnDefinitions �� $
��auto ��� $
��auto � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� #��Z   	 LHead#��[ �� $��1��   Surname#��Z   LDescription#��[ �� -    ��Name$ TBoxSurname��$��2��$��	10,0,0,20q�$
��Left=�$	��300��   RequiredFillIn)  #MaterialDesignThemes.Wpf.HintAssist   
HelperText# Z 	 �� 	MaxLength$	 50��
���   � ! MaterialDesignOutlinedTextBox#��[ ���� *	Surname+
 �� UpdateSourceTrigger$
 PropertyChanged=��� $��3��   	Firstname#��Z #��[ �� -   $ TBoxFirstname��$��4��$��	10,0,0,20q�$
��Left=�$	��300��# Z $	 30��
���   �#��[ ���� *	Firstname+$
 PropertyChanged=��� $��5��   
Middlename#��Z #��[ �� -   $ TBoxMiddlename��$��6��$��	10,0,0,20q�$
��Left=�$	��300��$	 60��
���   �#��[ ���� *
Middlename+$
 PropertyChanged=��� $��1��$��1��   Gender#��Z #��[ �� -    ��Name$ 
CBoxGender��$��2��$��1��$��10,0,0,0q�$
��Left=�$	��300��$	��Top=� �� 
IsEditable .  �� IsTextSearchEnabled .  �� DisplayMemberPath$
 Name��
���   �# Z  " MaterialDesignOutlinedComboBox#��[  �� SelectedItem �� *Gender+$
 PropertyChanged=� �� Mode$ OneWayToSource=��� $��3��$��1��   	GroupName#��Z #��[ �� -   $ 	CBoxGroup��$��4��$��1��$��10,0,0,0q�$
��Left=�$	��300��$	��Top=� .  . $
 Name��
���   �# Z #��[  �� *Group+$
 PropertyChanged=�$ OneWayToSource=��� $��5��$��1��   Specialization#��Z #��[ �� -   $ CBoxSpecialization��$��6��$��1��$��10,0,0,0q�$
��Left=�$	��300��$	��Top=� .  . $ SpecializationCodeName��
���   �# Z #��[  �� *Specialization+$
 PropertyChanged=�$ OneWayToSource=��� -    ��Name$ 	BtnCancel��$��7��$��5q�   Cancel#��Z  ! MaterialDesignFlatMidBgButton#��[ �� -   $ BtnAdd��$��7��$��1��$��5q�#��Z   * &MaterialDesignFlatSecondaryMidBgButton#��[ 