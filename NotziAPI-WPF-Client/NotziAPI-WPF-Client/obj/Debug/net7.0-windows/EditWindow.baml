   M S B A M L   `   `   `  ����N  JNotizAPI-WPF-Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:NotizAPI_WPF_ClientNotizAPI_WPF_Client  5      $    NotizAPI_WPF_Client.EditWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      3local!clr-namespace:NotizAPI_WPF_Client     5        � Title$  
EditWindow��5	      $	��450��6   $	��800��6%      CustomWindowStyle#���   5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"   $��Stretch=�62   .+�5      �� -   5         ��Name$ 
NoteHeader��5      $��5,0,5,10q�6*   6Y   5      ]� 5   
   $��1��6   $��0��6!   $��Stretch=�61   .+�5      �� -   5        $ NoteText��5      $��5,0,5,0q�6(   " �� VerticalScrollBarVisibility$
 Auto=�6:    �� TextWrapping$
 Wrap=�6]    �� AcceptsReturn$
 true��6q   6�   5      5      5      