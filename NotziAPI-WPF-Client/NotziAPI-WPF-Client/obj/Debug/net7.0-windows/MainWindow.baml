   M S B A M L   `   `   `  ����N  JMdXaml, Version=1.19.0.0, Culture=neutral, PublicKeyToken=9f8c7afb435b7edc/$clr-namespace:MdXaml;assembly=MdXamlMdXaml  5      N JNotizAPI-WPF-Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:NotizAPI_WPF_ClientNotizAPI_WPF_Client 5      $   NotizAPI_WPF_Client.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6mdxam$clr-namespace:MdXaml;assembly=MdXaml     5      3local!clr-namespace:NotizAPI_WPF_Client     5        � Title$  
MainWindow��5
      $	��450��6   $	��800��6%      CustomWindowStyle#���   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� $
��File��6   .@�5      m� -   5        $	��New��5      6(   m� 5      -   5        $
��Open��5      6)   m� 5      -   5        $
��Save��5      6)   m� 5      -   5        $��
Change URL��5      6/   m� 5      -   5        $
��Exit��5      6)   5      5      �� 5   
   -   5         ��Name$ NoteList��5      $��1��6$   $��0��61   $	��120��6A    � 	Resources 5        MyElementMenu �� 
TargetType �� Property �� Value��%�   &	       '�� �     7  �� 5       .@�5!      m� -   5        $
��Edit��5!      6-   m� 5"      -   5        $��Delete��5"      6/   5#      �� 5$      " ��6   .�5%      ��  �@�ContextMenu8   64   5&      5'      5(      ]� 5)   
   $��2��6   $��1��6!   $��Stretch=�61   .+�5*      (  "System.Windows.Controls.WebBrowser  -	   5          Name$ 
WebBrowser��5*      $��Hidden=�6-   6a   5+      5,      5-      