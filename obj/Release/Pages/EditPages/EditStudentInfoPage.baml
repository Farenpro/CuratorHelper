   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 7    1CuratorHelper.Pages.EditPages.EditStudentInfoPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     6sys&clr-namespace:System;assembly=mscorlib     $	��500��$
��1010��$
��1010��$	��500��$��16(�(   "CuratorHelper.Properties.Resources    EditInfo N� Title# Z     FontMain N� 
FontFamily# [  .��� $��5q� � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��1��   Surname#��Z   LDescription#��[ �� -    ��Name$ TBoxSurname��$��2��$��	10,0,0,20q�$
��Left=�$	��300��   RequiredFillIn)  #MaterialDesignThemes.Wpf.HintAssist   
HelperText# Z 	 �� 	MaxLength$	 50��
���   � ! MaterialDesignOutlinedTextBox#��[ ���� *	Surname+
 �� UpdateSourceTrigger$
 PropertyChanged=��� $��3��   	Firstname#��Z #��[ �� -   $ TBoxFirstname��$��4��$��	10,0,0,20q�$
��Left=�$	��300��# Z $	 30��
���   �#��[ ���� *	Firstname+$
 PropertyChanged=��� $��5��   
Middlename#��Z #��[ �� -   $ TBoxMiddlename��$��6��$��	10,0,0,20q�$
��Left=�$	��300��$	 60��
���   �#��[ ���� *
Middlename+$
 PropertyChanged=� �� TargetNullValue Z� �� $��7��   	Birthdate#��Z #��[ (  "System.Windows.Controls.DatePicker  -     Name$ DPBirthdate��$��8��$��
15,5,15,15q�$
��Left=�$	��300��   FirstDayOfWeek$ Monday=�|�.     BirthdateToolTip � ToolTip# Z 
���   �*  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$ Light=� $  MaterialDesignOutlinedDatePicker#��[    SelectedDate �� *	Birthdate+$
 PropertyChanged=� �� Mode$ OneWayToSource=� Z� �� $��1��$��1��   Gender#��Z #��[ �� -    ��Name$ 
CBoxGender��$��2��$��1��$��10,0,0,0q�$
��Left=�$	��300��$	��Top=� �� 
IsEditable .  �� IsTextSearchEnabled .  �� DisplayMemberPath$
 Name��
���   �# Z  " MaterialDesignOutlinedComboBox#��[  �� SelectedItem �� *Gender+$
 PropertyChanged=�$ OneWayToSource=��� $��3��$��1��   
BirthPlace#��Z #��[ �� -   $ TBoxBirthPlace��$��4��$��1��$��	10,0,0,20q�$
��Left=�$	��300��$		 100��
���   �#��[ ���� *
BirthPlace+$
 PropertyChanged=� Z� �� $��5��$��1��   CompletedClasses#��Z #��[ �� -   $ CBoxCompletedClasses��$��6��$��1��$��
15,5,15,15q�$
��Left=�$	��300�� .  . 
���   �#��[  �� SelectedIndex$ 3�� �� SelectedValue �� *CompletedClasses+$
 PropertyChanged=�$ OneWayToSource=� Z� ����   �� Type"  ��.s���9����11���� $��7��$��1��!   SchoolGraduate#��Z! #��[   -   $ DPSchoolGraduate��$��8��$��1��$��
15,5,15,15q�$
��Left=�$	��300��$ Monday=�|�.  "   SchoolGraduateToolTip# Z" 
���   �$ Light=�#��[  �� *SchoolGraduate+$
 PropertyChanged=�$ OneWayToSource=� Z� �� $��1��$��2��#   
SchoolName#��Z# #��[ �� -	   $ TBoxSchoolName��$��2��$��2��$��	10,0,0,20q�$	��300��$
��Left=�$	��300��$		 100��
���   �#��[ ���� *
SchoolName+$
 PropertyChanged=� Z� �� $��3��$��2��$   GuardianAddress#��Z$ #��[ �� -
   $ TBoxGuardianAddress��$��4��$��2��$��	10,0,0,20q�$	��300��$
��Left=�$	��300��$		 100��
���   �#��[ ���� *GuardianAddress+$
 PropertyChanged=� Z� �� $��5��$��2��%   AimedAt#��Z% #��[ �� -   $ TBoxAimedAt��$��6��$��2��$��	10,0,0,20q�$	��300��$
��Left=�$	��300��$	 50��
���   �#��[ ���� *	AimedAt+$
 PropertyChanged=� Z� �� $��7��$��2��&   CommunityService#��Z& #��[ �� -   $ TBoxCommunityService��$��8��$��2��$��	10,0,0,20q�$	��300��$
��Left=�$	��300��$		 400��
���   �#��[ ���� *CommunityService+$
 PropertyChanged=� Z� �� -   ' ��Name$' 	BtnCancel��$��9��$��5q�(   Cancel#��Z(  ! MaterialDesignFlatMidBgButton#��[ �� -   $' BtnEdit��$��9��$��1��$��2��$��5q�)   Edit#��Z)  * &MaterialDesignFlatSecondaryMidBgButton#��[ 