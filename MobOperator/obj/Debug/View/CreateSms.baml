   M S B A M L   `   `   `  ����F  BMobOperator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MobOperator.ViewMobOperator.View  5           MobOperator.View.CreateSms   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MobOperator.View     5      .��5	      �   � ColumnDefinitions  5   
   �� 5      $��0.08* �6   �� 5      $��0.30* �6   �� 5      $��* �6   �� 5      $
��0.1* �6   �� 5      $��0.08* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      $��* �6   .+�5#   
   �� 
�������
�������$��0��6=   $��10��6M   $��1q�6b   $��20��6v   5$      �� 5%   
   $��0��6   $��10��6!   $��0��66   $	��100��6C   $��20q�6W   $	��Top=�6c   $��Center=�6}   $��20(�6�   $
��Bold"�6�   $��Добавить СМС��6�   �� 5&   
   
�������
������� �� CornerRadius$ 10��6A   $��3��6S   $��1��6g   $��1q�6w   $��2��6�   $��10��6�   5'      �� 5(   
   $��1��6   $��3��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   $��От кого СМС��6w   �� 5*   
   $��2��6v   $��3��6�   $��Bottom=�6�   ��6   �� *TextBoxRecipientSms+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5+   
   $��1��6   $��5��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   $#��Когда отправили��6w   �� 5-   
   $��2��6q   $��5��6�   $��Bottom=�6�   ��6   �� *TextBoxDateSms+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5.   
   $��1��6   $��7��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   $��Текст СМС��6w   �� 5/   
   $��2��6q   $��7��6�   $��Bottom=�6�   ��6   �� *TextBoxTextSMS+$ OneWayToSource=�$ PropertyChanged=�6�   �� 50   
   $��1��6   $��9��6    $��Bottom=�6-   $��Center=�6H   $
��Bold"�6e   $��Кто звонит��6w   �� 51   
    �� SelectedValuePath$ Content��6�   $��2��6�   $��9��6�   $��Bottom=�6�    �� SelectedValue 6   �� *ComboBoxWhoSmsSelected+$ OneWayToSource=�$ PropertyChanged=���6�   �� *ComboBoxWhoSmsItems+.@�52      �� $��Исходящий��6    �� 
IsSelected . 6/   �� 53      $��Входящий��6   54      �� 55   
   $��2��6G   $��13��6W   $��Center=�6e   $	��300��6�   ��6   �� *LoadCreateSmsInDb+$ OneTime=�.��6�   Добавить СМС56      57      58      