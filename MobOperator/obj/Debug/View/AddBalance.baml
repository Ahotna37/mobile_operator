   M S B A M L   `   `   `  ����F  BMobOperator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MobOperator.ViewMobOperator.View  5      !    MobOperator.View.AddBalance   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MobOperator.View     5      
�������.��5
      �   � ColumnDefinitions  5   
   �� 5      $��0.08* �6   �� 5      $��0.30* �6   �� 5      $��* �6   �� 5      $
��0.1* �6   �� 5      $��0.08* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      $��* �6   .+�5)   
   �� 
�������
�������$��0��6=   $��3��6M   $��1q�6a   $��16��6u   5*      �� 5+   
   $��0��6   $��10��6!   $��0��66   $	��100��6C   $��20q�6W   $	��Top=�6c   $��Center=�6}   $��20(�6�   $
��Bold"�6�   .��6�   Пополнить счет5,      �� 5.   
   
�������
������� �� CornerRadius$ 10��6A   $��3��6S   $��1��6g   $��1q�6w   $��2��6�   $��13��6�   5/      �� 50   
   $��1��6   $��3��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   .��6w   Номер телефона51      �� 52   
   $��2��6   $��3��6�   $��Bottom=�6�   ��6   �� *TextBoxNumberPhoneForAddText+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 53   
   $��1��6   $��5��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   .��6w   !Сумма пополнения54      �� 55   
   $��2��6w   $��5��6�   $��Bottom=�6�   ��6   �� *TextBoxSumForAddText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 56   
   $��1��6   $��7��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   .��6w   Номер карты57      �� 58   
   $��2��6~   $��7��6�   $��Bottom=�6�   ��6   �� *TextBoxNumberBankCardText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 59   
   $��1��6   $��9��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   .��6w   Владелец карты5:      �� 5;   
   $��2��6{   $��9��6�   $��Bottom=�6�   ��6   �� *TextBoxNameOfBankCardText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5<   
   $��1��6   $��11��6    $��Bottom=�6.   $��Center=�6I   $
��Bold"�6f   .��6x   " Срок службы карты5=      �� 5>   
   $��2��6y   $��11��6�   $��Bottom=�6�   ��6   �� *TextBoxDateBankCardText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5?   
   $��1��6   $��13��6    $��Bottom=�6.   $��Center=�6I   $
��Bold"�6f   .��6x   CVV5@      �� 5A   
   $��2��6p   $��13��6�   $��Bottom=�6�   ��6   �� *TextBoxCVVText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5B   
   $��2��6   $��16��6"   $��Bottom=�62   $��20(�6O   $��Center=�6_   
��� E��$
��Bold"�6�   ��6�   �� *LabelErrorAddBalance+$ TwoWay=�$ PropertyChanged=�6�   �� 5C   
   $��2��6H   $��18��6X   $��Center=�6f   $	��300��6�   ��6   �� *LoadAddBalanceInDb+$ OneTime=�.��6�   Пополнить5D      5E      5F      