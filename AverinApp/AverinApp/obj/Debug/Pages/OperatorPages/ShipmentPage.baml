   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      D @AverinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AverinApp.Pages.OperatorPagesAverinApp.Pages.OperatorPages 5      7 clr-namespace:AverinApp.ControlsAverinApp.Controls 5      0   *AverinApp.Pages.OperatorPages.ShipmentPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      7System&clr-namespace:System;assembly=mscorlib    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:AverinApp.Pages.OperatorPages     5      5controls clr-namespace:AverinApp.Controls     5        N� Title$I  CОператор. Отправка товаров со склада��5      .��5      � .+�5   
   � $��10q�6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��    TbkBody#��[  6   $��Отправка №��6=   �� 5      #��[  6   $��0 5 5 5q�6e   $
��Bold"�6v   ��6=   �� *ShipmentContractNumber+6v   5      �� 5      $ 
Horizontal=�6   $��Right=�62   .+�5      �� #��[  6   $��Общий вес:��6=   $
��Bold"�6O   �� 5      #��[  6   ��6=   �� *TotalWeight+ �� StringFormat$ 
{0:N3} т.��5      � 5      $��1��6    � ColumnDefinitions 5       �� 5!      $	��400 �6'   �� 5"      $��2 �6'   �� 5#      $��* �6'   .+�5&      �� $
��15 5q�6   $��Center=�6+   .+�5'      �� #��[  6    $��	Цена:��6A   �� 5(      -   5        $��TbxPrice��5(   9   $
��Left=�6    �� 	MaxLength$ 13��6I   $��0��6X    �� TextAlignment$ Center=�5)      $	��150��65   6A   �� 5*      #��[  6    $��Поставщик:��6A   �� 5+      -   5        $��CbxProvider��5+      $
��auto��62    �� DisplayMemberPath$
 Info��6?   �� 5,      #��[  6    $��Клиент:��6A   �� 5-      -   5        $��	CbxClient��5-      $
��auto��60   $
 Info��6=   5.      � 50      $��1��6     PColor_Second#��[ 6'   $
��0 10q�6S   �� 52      $��2��6   .��53      �� -   5        $��
ICProducts��53   #   $��Center=�65   ��54      �� 55      .R�56   "   �  � Orientation$ 
Horizontal=�6,   57      ��59      �� 5:      .R�5;   "   � $	��310��6'   $	��Top=�63   $��Center=�6K   $��10q�6h    5<   &   �� 5=   *   $��* �68   �� 5>   *   $��6 �68   .+�5@   &   �� .+�5A   *   �� $ 
Horizontal=�65   .+�5B   .   �� #��[  68   	 �� TextAlignment$	 Right=�6Y   $	��115��6o   $��Наименование:��5C   @   $	��Top=�6U   $
��Bold"�6m   �� 5D   .   #��[  68   $
��Wrap=�6Y   $	��180��6m   ��6y   �� *Product.Name+5E   +   �� 5F   *   $ 
Horizontal=�65   .+�5G   .   �� #��[  68   $
��Left=�6Y   $	 Right=�6t   $	��115��5H   @   $��Количество:��6L   $
��Bold"�6_   �� 5I   .   $��TbxProductCount��6f   -   5        $��60��5I   6   $ 5��6A   $ Center=�6O   $��1��6}   $��Right=�5K   d   ��66   �� *Count+$ {0:N0}��6d   �� 5L   .   #��[  68   $
��Left=�6Y   $	 Right=�6u   $
��auto��5M   @   $
��Bold"�6�   ��6M   �� *
TotalCount+$ 
/ {0}шт.��6�   5N   +   5O   '   � 5Q   &   $��1��6+   #��[ 68   $��0 5 0 0q�6d   5R   #   5S      5U      5V      5X      �� 5Z      $ 
Horizontal=�6   $��2��62   $��Center=�6?   .+�5[      �� -   5        $��BtnCreateShipment��5[      $%��Создать отправку��6R   $
��15 5q�6m   $
��auto��6|   �� 5\      -   5        $��BtnShipmentClear��5\      $��Очистить всё��6P   $
��15 5q�6g   $
��auto��6v     	BtnCancel#��[ 6�   5]      5^      5_      5`      