   M S B A M L   `   `   `  ����  Management-Hotel=    7Management_Hotel.Views.Dialogs.AddEditReservationDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Gestion des Réservations��5   	   $	��600��6*   $	��500��67    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� $��20q�6   .+�5   
   �� $!��Détails de la réservation��6   $��20(�65   $��0,0,0,20q�6C   �� 5	   
   $��Client��6   �� 5
   
   -   5         ��Name$ ClientComboBox��5
       �� DisplayMemberPath$	 Nom��5       �� SelectedValuePath$ Idclient��5      $��0,5,0,10q�5      �� 5   
   $��Date d'arrivée��6   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DateArriveePicker��5      $��0,5,0,10q�60   �� 5   
   $��Date de départ��6     5   
   -   5        $ DateDepartPicker��5      $��0,5,0,10q�6/   �� 5   
   $��Type de chambre��6   �� 5   
   -   5        $ RoomTypeComboBox��5      $ Libelle��5      $ Idtype��5      $��0,5,0,10q�5      �� 5   
   $��Statut��6   �� 5   
   -   5        $ StatusComboBox��5      $��0,5,0,20q�6+   .@�5      �� $��
En attente��6   �� 5      $��
Confirmée��6   �� 5      $��Annulée��6   5       �� 5"   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5#      �� -   5        $��Annuler��5#      $	��100��6B   $��0,0,10,0q�6N   �� 5$      -   5        $��Enregistrer��5$      $	��100��6D   5%      5&      5'      