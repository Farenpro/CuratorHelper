   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  0    *CuratorHelper.Pages.EditPages.AddGroupPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��430��$	��680��$	��400��$	��430��$��16(�(   "CuratorHelper.Properties.Resources    AddGroup N� Title# Z     FontMain N� 
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
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto �.+��� #��Z   	 LHead#��[ �� $��1��   	GroupName#��Z   LDescription#��[ �� -    ��Name$ TBoxGroupName��$��2��$��	10,0,0,20q�$
��Left=�$	��300��   RequiredFillIn)  #MaterialDesignThemes.Wpf.HintAssist   
HelperText# Z 	 �� 	MaxLength$	 30��
���   � ! MaterialDesignOutlinedTextBox#��[ ���� *	GroupName+
 �� UpdateSourceTrigger$
 PropertyChanged=��� $��3��   Curator#��Z #��[ �� -    ��Name$ CBoxCurator��$��4��$��
15,5,15,15q�$
��Left=�$	��300�� �� 
IsEditable .  �� IsTextSearchEnabled .  �� DisplayMemberPath$	 FIO��
���   �# Z  " MaterialDesignOutlinedComboBox#��[  �� SelectedItem �� *	Curator+$
 PropertyChanged=� �� Mode$ OneWayToSource=��� $��5��   Specialization#��Z #��[ �� -   $ CBoxSpecialization��$��6��$��
15,5,15,15q�$
��Left=�$	��300�� .  . $
 Name��
���   �# Z #��[  �� *Specialization+$
 PropertyChanged=�$ OneWayToSource=��� $��3��$��1��   
Department#��Z #��[ �� -   $ CBoxDepartment��$��4��$��1��$��
15,5,15,15q�$
��Left=�$	��300�� .  . $
 Name��
���   �# Z #��[  �� *
Department+$
 PropertyChanged=�$ OneWayToSource=��� $��1��$��1��   StartStudyDate#��Z #��[ (  "System.Windows.Controls.DatePicker  -     Name$ DPStartStudyDate��$��2��$��1��$��
15,5,15,15q�$
��Left=�$	��300��   FirstDayOfWeek$ Monday=�|�.     StartStudyDateToolTip � ToolTip# Z # Z 
���   �*  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$ Light=� $  MaterialDesignOutlinedDatePicker#��[    SelectedDate �� *StartStudyDate+$
 PropertyChanged=�$ OneWayToSource=��� -    ��Name$ 	BtnCancel��$��10��$��5q�   Cancel#��Z  ! MaterialDesignFlatMidBgButton#��[ �� -   $ BtnAdd��$��10��$��1��$��5q�#��Z   * &MaterialDesignFlatSecondaryMidBgButton#��[ 