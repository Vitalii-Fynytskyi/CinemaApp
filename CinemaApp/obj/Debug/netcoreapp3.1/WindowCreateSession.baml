   M S B A M L   `   `   `  ����D  @CinemaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CinemaApp	CinemaApp  5   	   #    CinemaApp.WindowCreateSession   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CinemaApp     5   	     � Title$  Новий сеанс��5   	   $	��300��6   $	��300��6)   .��5	      �� .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   $��0,10,0,0q�6.   .+�5      �� $��
Фільм��6   �� 5      -   5         ��Name$ comboBoxMovieNames��5      $��10,0,0,0q�63    �� DisplayMemberPath$ Title��6E    �� SelectedValuePath$ Title��6_   6y   �� 5      -   5         ��Name$ LabelMovieDuration��5      $��Тривалість: ��60   $��10,0,0,0q�6G   5      �� 5   
   $ 
Horizontal=�6   $��0,10,0,0q�6.   .+�5      �� $��Номер залу��6   �� 5      -   5        $ comboBoxAuditoriums��5      $��10,0,0,0q�64   $ InternalNumber��6F   $ InternalNumber��6i   6�   �� 5      -   5        $ LabelCountPlaces��5      $%��Кількість місць: ��6.   $��10,0,0,0q�6J   5      �� 5   
   $ 
Horizontal=�6   $��0,10,0,0q�6.   .+�5      �� $��Дата початку��6   �� 5      -   5         ��Name$ textBoxStartDate��5      $��10,0,0,0q�60   $	��120��6B   5      �� 5   
   $ 
Horizontal=�6   $��0,10,0,0q�6.   .+�5      �� $��Дата кінця��6   �� 5      -   5        $ textBoxEndDate��5      $��10,0,0,0q�6.   $	��120��6@   5      �� 5   
   $ 
Horizontal=�6   $��0,10,0,0q�6.   .+�5      �� $��Ціна квитка��6   �� 5      -   5        $ textBoxTicketPrice��5      $��10,0,0,0q�62   $	��120��6D   5      �� 5    
   $ 
Horizontal=�6   $��0,10,0,0q�6.   .+�5!      �� $��Тип сеансу��6   �� 5"      -   5        $ comboBoxSessionType��5"      $��10,0,0,0q�64   .@�5#      �� .��6   2D6#   �� 5$      .��6   3D6#   5%      5&      �� 5'   
   -	   5         ��Name$ buttonCreateNewSession��5'      $!��Створити сеанс��61   $��Center=�6J   $��0,20,0,0q�6g   6y   5(      5)      