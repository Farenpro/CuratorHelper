   M S B A M L   `   `   `  ���� H  DCuratorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CuratorHelper.PropertiesCuratorHelper.Properties  5    /CuratorHelper.Pages.EditPages.AddDisciplinePage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6res&clr-namespace:CuratorHelper.Properties     $	��340��$	��400��$	��400��$	��340��$��16(�(   "CuratorHelper.Properties.Resources    AddDiscipline N� Title# Z     FontMain N� 
FontFamily# [  .��� $��5q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto �.+��� #��Z   	 LHead#��[ �� $��1��   Name#��Z   LDescription#��[ �� -    ��Name$ CBoxObjects��$��2��$��
15,5,15,15q�$
��Left=�$	��300�� �� 
IsEditable .  �� IsTextSearchEnabled . 	 �� DisplayMemberPath$
	 Name��
���   �
   RequiredFillIn)  #MaterialDesignThemes.Wpf.HintAssist   
HelperText# Z
  " MaterialDesignOutlinedComboBox#��[  �� SelectedItem �� *Object+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWayToSource=��� -    ��Name$ BtnObjectAdd��$��2��$��1��$
��Left=�$��0,0,0,10q�   	AddObject � ToolTip# Z 
�������  SecondaryHueMidBrush#���  $��0q����#076194+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=� * &MaterialDesignFloatingActionMiniButton#���  ��0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 	PencilAdd=��� $��3��   Index#��Z #��[ �� -   $ CBoxIndexes��$��4��$��
15,5,15,15q�$
��Left=�$	��300�� .  . $
	 Name��
���   �# Z
 #��[  �� *DisciplineIndex+$ PropertyChanged=�$ OneWayToSource=��� $��5�� �� Orientation$ 
Horizontal=�$��5q�.+��� -   $ 	BtnCancel��$��5q�   Cancel#��Z  ! MaterialDesignFlatMidBgButton#��[ �� -   $ BtnAdd��$��5q�#��Z   * &MaterialDesignFlatSecondaryMidBgButton#��[ 