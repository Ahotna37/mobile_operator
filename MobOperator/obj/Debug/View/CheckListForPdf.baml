   M S B A M L   `   `   `  ����F  BMobOperator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MobOperator.ViewMobOperator.View  5   	   &     MobOperator.View.CheckListForPdf   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MobOperator.View     5   	     � Title$  CheckListForPdf��5   	   $
��1000��6!   $	��800��6/   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��0.1* �6   �� 5      $��* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 Call��5      $��0��6!   $��1��6.      CanUserAddRows .     AutoGenerateColumns .  ��6>   �� *Call+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 0.26* 6Z   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 63   �� 
 �� Path$
 dateCallShort�6Z     5      $ 
Время��6%   $
 0.2* 6V   	 64   �� $
 timeTalk�6V     5      $ Собеседник��6%   $
 0.3* 6`   	 69   �� $
 numberWasCall�6`     5      $ Дистанция��6%   $ 0.35* 6`   	 68   �� $
 callTypeString�6`     5      $ Цена��6%   $
 0.2* 6U   	 63   �� $
 costCall�6U     5      $ Тип звонка��6%   $
 0.3* 6c   	 69   �� $
 incomingCallText�6c   5        5    
   -   5        $	 Sms��5       $��1��6    $��1��6-    .   .  ��6=   �� *Sms+ 5!        5#      $ Дата��6%   $
 0.2* 6Y   	 63   �� $
 dateSmsShort�6Y     5$      $ Отправитель��6%   $
 0.2* 6`   	 6:   �� $
 recipientSms�6`     5%      $ Текст СМС��6%   $
 0.6* 6Z   	 68   �� $
 textSms�6Z     5&      $ Стоимость��6%   $ 0.18* 6Y   	 68   �� $
 costSMS�6Y   5(      5)      5*      