   M S B A M L   `   `   `  ����F  BMobOperator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MobOperator.ViewMobOperator.View  5          MobOperator.View.Tariff   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MobOperator.View     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6;   .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��0* �6   �� 5      �� 5      $	��10* �6   �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      $��* �6   .+�5#   
   �� 
�������
�������$��0��6<   $��4��6L   $��1q�6`   $��20��6t   5$      �� 5%   
   $��2��6   $��0��6    $��2��6-   $	��Top=�6@   $��Center=�6Z   $��20(�6x   $
��Bold"�6�   .��6�   Тарифы5&      � 5'   
   $��2��6   $��2��6   $��11��6,     5(      �� 5)      �� 5*      $��0.05* �6#   �� 5+       5-      �� 5.      $
��0.9* �6    �� 5/      �� 50      �� 51      �� 52      �� 53      �� 54      �� 55      �� 56      .+�58      �� 
�������
������� �� CornerRadius$ 10��6F   $��9��6X   $��3��6i   59      �� 5:      -   5         ��Name$
 List��5:      $��0��6�   $��0��6�   $��10��6�    �� SelectedValue 6&   �� *ListViewTariffSelected+ �� Mode$ TwoWay=���6d   �� *
TariffPlan+ �� View 5;      �� 5<      .P�5=      ��  �� DisplayMemberBinding 6)   �� *name+5>      5?      5A      �� 5B      $��0��6   $��0��6$   $
��Bold"�61   $��14(�6C   $��Center=�6Q   .��6n   Название5C      �� 5D      $��14(�6N   $��2��6\   $��0��6l   $
��Bold"�6y   $��Center=�6�   ��6   �� *CharachteristicTariff+$ TwoWay=�6�   �� 5F      $��2��6H   $��1��6X   $
��Bold"�6e   ��6   �� *LabelCostTariff+$ TwoWay=�6e   �� 5G      $��2��6L   $��2��6\   $
��Bold"�6i   ��6   �� *LabelFreeMinInMonth+$ TwoWay=�6i   �� 5H      $��2��6Q   $��3��6a   $
��Bold"�6n   ��6   �� *LabelFreeInternetInMonth+$ TwoWay=�6n   �� 5I      $��2��6L   $��4��6\   $
��Bold"�6i   ��6   �� *LabelFreeSmsInMonth+$ TwoWay=�6i   �� 5J      $��2��6H   $��5��6X   $
��Bold"�6e   ��6   �� *LabelOneMinCity+$ TwoWay=�6e   �� 5K      $��2��6K   $��6��6[   $
��Bold"�6h   ��6   �� *LabelOneMinOutCity+$ TwoWay=�6h   �� 5L      $��2��6O   $��7��6_   $
��Bold"�6l   ��6   �� *LabelOneMinInternation+$ TwoWay=�6l   �� 5M      $��2��6E   $��8��6U   $
��Bold"�6b   ��6   �� *LabelCostSms+$ TwoWay=�6b   5N      �� 5O   
   $��2��6�   $��14��6�   $��Center=�6�   $	��300��6�   $%��Подключить тариф��6�   {�6   �� *TariffChangeButtonsEnabled+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6v   �� *LoadChangeTariff+$ OneTime=�6�   5Q      5R      