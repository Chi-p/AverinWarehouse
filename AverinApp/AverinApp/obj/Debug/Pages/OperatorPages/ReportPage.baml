   M S B A M L   `   `   `  ����D  @AverinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AverinApp.Pages.OperatorPagesAverinApp.Pages.OperatorPages  5      .    (AverinApp.Pages.OperatorPages.ReportPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:AverinApp.Pages.OperatorPages     5        N� Title$$  Оператор. Отчёты��5	      .��5      � .+�5   
   �� -   5        $��SPType��5   M   $��Center=�6   $��Center=�62   $y�Visible=�6[   .+�5      ��    TbkBody#��[  6   $:��4Выберите тип данных в отчёте��69   $��24(�6]   $��5 5 5 15q�6k   �� 5      -   5        $��BtnSupplies��5   R   $
��auto��6   $
��25 5q�6"   $��20(�61   $��Отгрузки��6?   $��Center=�6e   6�   �� 5      -   5        $��BtnShipments��5   R   $
��auto��6   $
��25 5q�6"   $��20(�61   $��Поставки��6?   $��Center=�6f   6�   5      � 5   
   -   5        $��GridSupplies��5      $��5q�6#   $y�Hidden=�6.    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� #��[  6   $"��В промежутке от��6=   $��10 5 5 5q�6T   (  "System.Windows.Controls.DatePicker  5      -   5        $��DpSupplyStartDate��5      �� 5      #��[  6   $
��до��6=     5      -   5        $��DpSupplyEndDate��5      �� 5      -   5        $��BtnSupplyReport��5      $
��15 3q�6N   $
��auto��6]   $��Сформировать��6j   �� 5      -   5        $��BtnSupplyClear��5      $
��15 3q�6L   $
��auto��6[   $��Очистить��6h     	BtnCancel#��[ 6{   5       (  "System.Windows.Controls.WebBrowser  5"      -	   5        $��WBSupply��5"      $��1��6)   $��5q�66   $y�Hidden=�6A   �� 5$      -
   5        $��BtnSupplyBack��5$      $(��"Выбрать другой тип��6*   $
��15 3q�6G   $��2��6V   $
��auto��6c   $
��Left=�5%        BtnEdit#��[ 6L   �� 5&      -   5        $��BtnSupplyPrint��5&      $��Печать��6+   $
��25 3q�6<   $��2��6K   $
��auto��6X   $��Right=�6e   6�   5'      � 5)   
   -   5        $��GridShipments��5)      $��5q�6$   $y�Hidden=�6/    5*      �� 5+      $
��auto �6    �� 5,      $��* �6    �� 5-      $
��auto �6    .+�50      �� $ 
Horizontal=�6   $��Center=�62   .+�51      �� #��[  6   $"��В промежутке от��6=   $��10 5 5 5q�6T     52      -   5        $��DpShipmentStartDate��52      �� 53      #��[  6   $
��до��6=     54      -   5        $��DpShipmentEndDate��54      �� 55      -   5        $��BtnShipmentReport��55      $
��15 3q�6R   $
��auto��6a   $��Сформировать��6n   �� 56      -   5        $��BtnShipmentClear��56      $
��15 3q�6P   $
��auto��6_   $��Очистить��6l   #��[ 6   57        59      -   5        $��
WBShipment��59      $��1��6+   $��5q�68   $y�Hidden=�6C   �� 5;      -   5        $��BtnShipmentBack��5;      $(��"Выбрать другой тип��6,   $
��15 3q�6I   $��2��6X   $
��auto��6e   $
��Left=�5<      #��[ 6N   �� 5=      -   5        $��BtnShipmentPrint��5=      $��Печать��6-   $
��25 3q�6>   $��2��6M   $
��auto��6Z   $��Right=�6g   6�   5>      5?      5@      