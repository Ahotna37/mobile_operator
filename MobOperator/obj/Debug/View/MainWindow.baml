   M S B A M L   `   `   `  ����F  BMobOperator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MobOperatorMobOperator  5   	       MobOperator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MobOperator     5   	   
�������  � Title$  
MainWindow��5	   	   $	��555��6   $
��1000��6,   $	��675��6<   $
��1200��6I    � Icon$% /MobOperator;component/LOgo.ico��6V   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��8* �6   �� 5      $
��314* �6   �� 5      $��8* �6   �� 5      $
��39.2 �6   �� 5      $	��18* �6   �� 5      $
��767* �6   �� 5      $	��39* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      $��* �6   .+�5'   
   �� 
�������
�������$��0��6<   $��3��6L   $��1q�6`   $��17��6t   5(      �� 5)   
   $
��Wrap=�6B   $��1��6W   $��0��6g   $��Center=�6t   $
��Left=�6�   $��20(�6�   $
��Bold"�6�   ��6   �� *LabelNameUser+ �� Mode$ OneWay=�6�   �� 5+   
   $
��Wrap=�6J   $��1��6^   $��1��6n   $��Center=�6{   $
��Left=�6�   $��16(�6�   $��DemiBold"�6�   ��6   �� *LabelNumberPhoneUser+$ OneWay=�6�   �� 5-   
   $��1��6D   $��4��6T   $��Главная��6a   $��16(�6s   $��Center=�6�   ��6   �� *LoadMainWindow+$ OneTime=�6�   �� 5.   
   $��1��6D   $��6��6T   $%��Пополнить баланс��6a   $��Center=�6|   $��16(�6�   ��6   �� *LoadAddBalance+$ OneTime=�6�   �� 50   
   $��1��6D   $��8��6T   $��Звонки и СМС��6a   $��Center=�6x   $��16(�6�   ��6   �� *LoadCallAndSms+$ OneTime=�6�   �� 52   
   $��1��6@   $��10��6P   $��Center=�6^   $��Тарифы��6y   $��16(�6�   ��6   �� *
LoadTariff+$ OneTime=�6�   �� 54   
   $��1��6A   $��12��6Q   $��Center=�6_   $��Услуги��6z   $��16(�6�   ��6   �� *LoadService+$ OneTime=�6�   �� 57   
   -   5         ��Name$ ContentPresenterOutput��57   =   $��4��6   $��17��6+   $��2��6]   58      59      