   M S B A M L   `   `   `  ����F  BMobOperator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MobOperator.ViewMobOperator.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 6;   !    MobOperator.View.CallAndSms   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MobOperator.View     5      Bcol2clr-namespace:System.Collections;assembly=mscorlib     6;   .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��0.05* �6   �� 5      �� 5      $��0.05* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       $��* �6   .+�5"   
   �� 
�������
�������$��0��6<   $��3��6L   $��1q�6`   $��17��6t   5#      �� 5$   
   $��0��6   $��10��6!   $��0��66   $	��100��6C   $��20q�6W   $	��Top=�6c   $��Center=�6}   $��20(�6�   $
��Bold"�6�   $��Звонки и СМС��6�   �� 5%   
   $��1��6   $��2��6%   $��11��62   .@�5&      �� $��Звонки��6   $
��Bold"�6&   .��5'      � 
������� 5(      �� 5)      �� 5*      �� 5+      �� 5,      �� 5-      .+�5/      &   System.Windows.Controls.DataGrid  -   5          Name$
 Call��5/         CanUserAddRows .  $��20��6a      AutoGenerateColumns .  ��6-   �� *Call+   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 0.26* 6f   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� 	 �� Path$	 dateCallShort�6f     52      $ 
Время��61   $
 0.2* 6b    6@   �� $	 timeTalk�6b     53      $ Собеседник��61   $
 0.3* 6l    6E   �� $	 numberWasCall�6l     54      $ Дистанция��61   $ 0.35* 6l    6D   �� $	 callTypeString�6l     55      $ Цена��61   $
 0.2* 6a    6?   �� $	 costCall�6a     56      $ Тип звонка��61   $
 0.3* 6o    6E   �� $	 incomingCallText�6o   59      5:      5;      �� 5<      $��СМС��6   $
��Bold"�6#   .��5=      � 
������� 5>      �� 5?      �� 5@      �� 5A      �� 5B      �� 5C      .+�5E        -   5        $	 Sms��5E        .  $��20��6b    .  ��6/   �� *Sms+ 5F        5G      $ Дата��61   $
 0.2* 6e    6?   �� $	 dateSmsShort�6e     5H      $ Отправитель��61   $
 0.2* 6l    6F   �� $	 recipientSms�6l     5I      $ Текст СМС��61   $
 0.6* 6f    6D   �� $	 textSms�6f     5J      $ Тип��61   $
 0.2* 6h    6>   �� $	 incomingSmsText�6h     5L      $ Стоимость��61   $ 0.18* 6e    6D   �� $	 costSMS�6e   5O      5P      5Q      5R      �� 5S   
   $��1��6D   $��14��6T   $	��150��6b   $#��Добавить звонок��6q   $
��Left=�6�   ��6   �� *LoadCreateCall+
 �� Mode$
 OneTime=�6�   �� 5T   
   $��1��6C   $��14��6S   $	��150��6a   $��Добавить СМС��6p   $��Center=�6�   ��6   �� *LoadCreateSms+$
 OneTime=�6�   �� 5U   
   $	��150��6�   $��Right=�6�   $
��Bold"�6�    �� SelectedValuePath$ Content��6�   $��16(�6�   $��1��6   $��15��60  $��Bottom=�6?   �� SelectedValue 6   �� *ComboBoxDateCheckListSelected+$
 OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *ComboBoxDateCheckList+.@�5V      �� $��Неделя��6    �� 
IsSelected . 6,   �� 5W      $��
Месяц��6   �� 5X      $��Год��6   �� 5Y      $��Все время��6   5[      �� 5\   
   $��1��6I   $��14��6Y   $��Center=�6g   $��Выписка ��6�   $��Right=�6�   $	��150��6�   $��16(�6�   ��6   �� *LoadCheckListForPdf+$
 OneTime=�6�   5]      5^      