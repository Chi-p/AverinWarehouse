   M S B A M L   `   `   `  ����D  @AverinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:AverinApp.Windows.AdditionalWindows#AverinApp.Windows.AdditionalWindows  5   	   9    3AverinApp.Windows.AdditionalWindows.AddClientWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:AverinApp.Windows.AdditionalWindows     5   	     � Title$  AddClientWindow��5   	   $	��300��6!   $	��400��6.    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterOwner=�6P   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��10q�6   $��Center=�6!   .+�5      �� $��Название��6      TbkBody#��[  6(   $��5 5 5 0q�6I   �� 5      -   5        $��TbxName��5   3   $
��auto��6   $��0 5.5q�6#   63   �� 5      $��
Адрес��6   #��[  6%   $��5 5 5 0q�6F   �� 5      -   5        $��	TbxAdress��5   3   $
��auto��6   $��0 5.5q�6#   63   �� 5      $��Телефон��6   #��[  6'   $��5 5 5 0q�6H   �� 5      -   5        $��TbxPhone��5   3   $
��auto��6   $��0 5.5q�6#   63   5      �� 5   
   $��1��6   $��Center=�6"   $��Center=�6?    �� Orientation$ 
Horizontal=�6Z   .+�5      �� -   5        $��BtnSave��5   E   $
��15 4q�6   $
��auto��6$   $��Сохранить��61   6T   �� 5      -   5        $��	BtnCancel��5   B   $
��15 4q�6   $
��auto��6$   $��Отмена��61     	BtnCancel#��[ 6k   5      5      5      