   M S B A M L   `   `   `  ����F  BMobOperator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MobOperator.ViewMobOperator.View  5      !    MobOperator.View.CreateCall   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MobOperator.View     5      .��5	      �   � ColumnDefinitions  5   
   �� 5      $��0.08* �6   �� 5      $��0.30* �6   �� 5      $��* �6   �� 5      $
��0.1* �6   �� 5      $��0.08* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      $��* �6   .+�5%   
   �� 
�������
�������$��0��6=   $��10��6M   $��1q�6b   $��20��6v   5&      �� 5'   
   $��0��6   $��10��6!   $��0��66   $	��100��6C   $��20q�6W   $	��Top=�6c   $��Center=�6}   $��20(�6�   $
��Bold"�6�   $#��Добавить звонок��6�   �� 5(   
   
�������
������� �� CornerRadius$ 10��6A   $��3��6S   $��1��6g   $��1q�6w   $��2��6�   $��11��6�   5)      �� 5*   
   $��1��6   $��3��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   $��Собеседник��6w   �� 5,   
   $��2��6t   $��3��6�   $��Bottom=�6�   ��6   �� *TextBoxWhoWasCall+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5-   
   $��1��6   $��5��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   $��Когда звонили��6w   �� 5/   
   $��2��6r   $��5��6�   $��Bottom=�6�   ��6   �� *TextBoxDateCall+$ OneWayToSource=�$ PropertyChanged=�6�   �� 50   
   $��1��6   $��7��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   $#��Время разговора��6w   �� 52   
   $��2��6t   $��7��6�   $��Bottom=�6�   ��6   �� *TextBoxTimeTalk+$ OneWayToSource=�$ PropertyChanged=�6�   �� 53   
   $��1��6   $��9��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   $��Тип звонка��6w   �� 54   
    �� SelectedValuePath$ Content��6�   $��2��6�   $��9��6�   $��Bottom=�6�    �� SelectedValue 6   �� *ComboBoxTypeCallSelected+$ OneWayToSource=�$ PropertyChanged=���6�   �� *ComboBoxTypeCallItems+.@�55      �� $��Городской��6    �� 
IsSelected . 6/   �� 56      $ ��Междугородний��6   �� 57      $"��В другую страну��6   59      �� 5:   
   $��1��6   $��11��6    $��Bottom=�6.   $��Center=�6I   $
��Bold"�6f   $��Кто звонит��6x   �� 5<   
   $ Content��6�   $��2��6�   $��11��6�   $��Bottom=�6�    6   �� *ComboBoxWhoCallSelected+$ OneWayToSource=�$ PropertyChanged=���6�   �� *ComboBoxWhoCallItems+.@�5=      �� $��Исходящий��6    . 6/   �� 5>      $��Входящий��6   5?      �� 5@   
   $��2��6H   $��14��6X   $��Center=�6f   $	��300��6�   ��6   �� *LoadCreateCallInDb+$ OneTime=�.��6�   Сделать звонок5A      5B      5C      