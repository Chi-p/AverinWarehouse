   M S B A M L   `   `   `  ����D  @AverinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:AverinApp.Windows.AdditionalWindows#AverinApp.Windows.AdditionalWindows  5   	   <    6AverinApp.Windows.AdditionalWindows.AddWarehouseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:AverinApp.Windows.AdditionalWindows     5   	     � Title$  AddWarehouseWindow��5   	   $	��300��6$   $	��500��61    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterOwner=�6S   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��10q�6   $��Center=�6!   .+�5      �� $��Название��6      TbkBody#��[  6(   $��5 5 5 0q�6I   �� 5      -   5        $��TbxName��5   3   $
��auto��6   $��0 5.5q�6#    �� 	MaxLength$ 30��6B   �� 5      $��
Адрес��6   #��[  6%   $��5 5 5 0q�6F   �� 5      -   5        $��	TbxAdress��5   3   $
��auto��6   $��0 5.5q�6#   63   � 5       � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      $��* �6'   �� 5      $
��auto �6'   .+�5      �� .+�5      �� $��Вместимость��6    #��[  63   $��5 5 5 0q�6T   �� 5      -   5        $��TbxCapacity��5   5   $��95��5      $
��Left=�6)   $��0 5.5q�6D   $ 10��6T    �� TextAlignment$ Center=�5      6H   5      �� 5      $��1��6   .+�5       �� $��Оператор��6    #��[  60   $��5 5 5 0q�6Q   �� 5!      -   5        $��CbxOperator��5!   I   $
��auto��6    �� DisplayMemberPath$ FullName��6,   6I   5"      �� 5#      -   5        $��BtnAddOperator��5#   u   $��2��6   $��Bottom=�6)   $��+��6D   $��32��6P   $��24(�6[   $��32��6i   6�   5$      5%      �� 5'   
   $��1��6   $��Center=�6"   $��Center=�6?    �� Orientation$ 
Horizontal=�6Z   .+�5(      �� -   5        $��BtnSave��5(   E   $
��15 4q�6   $
��auto��6$   $��Сохранить��61   6T   �� 5)      -   5        $��	BtnCancel��5)   B   $
��15 4q�6   $
��auto��6$   $��Отмена��61     	BtnCancel#��[ 6k   5*      5+      5,      