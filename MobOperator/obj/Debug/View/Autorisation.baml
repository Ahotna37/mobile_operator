   M S B A M L   `   `   `  ����E  ADragablz, Version=0.0.3.223, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz  5      F BMobOperator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MobOperator.ViewMobOperator.View 5      #   MobOperator.View.Autorisation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =dragablz(clr-namespace:Dragablz;assembly=Dragablz     5      0localclr-namespace:MobOperator.View     5      N
compontnts9http://schemas.microsoft.com/netfx/2007/xaml/presentation    6;   N
components9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $��0.12* �6   �� 5      $��0.35* �6   �� 5      $��* �6   �� 5      $��0.12* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      $��* �6   .+�5$   
   �� 
�������
�������$��0��6=   $��7��6M   $��1q�6a   $��16��6u   5%      �� 5&   
   $��0��6   $��10��6!   $��0��66   $	��100��6C   $��20q�6W   $	��Top=�6c   $��Center=�6}   $��25(�6�   $
��Bold"�6�   $��Авторизация��6�   �� 5'   
   $��1��6   $��3��6"   $��Bottom=�61   $��20(�6N   $
��Left=�6^   $��
Логин��6|   $
��Bold"�6�   �� 5(   
   $��2��6s   $��3��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   ��6   �� *TextBoxLoginText+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5)   
   $��1��6   $��5��6"   $��Bottom=�61   $��20(�6N   $
��Left=�6^   $��Пароль��6|   $
��Bold"�6�   G� 5*   
   $��2��6   $��5��6)   
���� ��$��0 0 0 1q�6S   $��Bottom=�6o   G� 5+   
   -   5        $��2��5+   D   $��5��6V   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   �� 5,   
   $��2��6   $��7��6"   $��Bottom=�61   $��20(�6N   $��Center=�6^   
��� E��$
��Bold"�6�   ��6�   �� *LabelErrorLog+$ TwoWay=�$ PropertyChanged=�6�   �� 5-   
   $��
Войти��6D   $��16(�6V   $��2��6e   $��9��6x   $	��400��6�   ��6   �� *LoadMainWindow+$ OneTime=�6�   �� 5.   
   $*��$Зарегистрироваться��6F   $��16(�6e   $��2��6t   $��11��6�   $	��400��6�   ��6   �� *LoadRegistration+$ OneTime=�6�   50      52      