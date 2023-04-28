import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { routes } from '../../core.index';
import { an } from '@fullcalendar/core/internal-common';

@Injectable({
  providedIn: 'root',
})
export class SidebarService {
  constructor() {
    if (localStorage.getItem('sideBarPosition') == 'expand') {
      this.expandSideBar.next(true);
    } else {
      this.expandSideBar.next(false);
    }
  }

  public sideBarPosition: BehaviorSubject<string> = new BehaviorSubject<string>(
    localStorage.getItem('sideBarPosition') || 'false'
  );

  public toggleMobileSideBar: BehaviorSubject<any> = new BehaviorSubject<any>(
    localStorage.getItem('isMobileSidebar') || false
  );

  public expandSideBar: BehaviorSubject<any> = new BehaviorSubject<any>(false);

  public switchSideMenuPosition(): void {
    if (localStorage.getItem('sideBarPosition')) {
      this.sideBarPosition.next('false');
      this.expandSideBar.next(true);
      localStorage.removeItem('sideBarPosition');
    } else {
      this.sideBarPosition.next('true');
      this.expandSideBar.next(false);
      localStorage.setItem('sideBarPosition', 'true');
    }
  }

  public switchMobileSideBarPosition(): void {
    if (localStorage.getItem('isMobileSidebar')) {
      this.toggleMobileSideBar.next(false);
      localStorage.removeItem('isMobileSidebar');
    } else {
      this.toggleMobileSideBar.next(true);
      localStorage.setItem('isMobileSidebar', 'true');
    }
  }

  private sidebarDataone: Array<any> = [
    {
      tittle: 'Inicio',
      showAsTab: true,
      separateRoute: false,
      menu: [
        {
          menuValue: 'Dashboard',
          route: routes.dashboard,
          hasSubRoute: false,
          showSubRoute: false,
          icon: 'grid',
          base: 'dashboard',
          subMenus: []
        },
      ]
    },
    {
      tittle: 'Cuentas por Crobar',
      showAsTab: true,
      separateRoute: false,
      menu: [
        {
          menuValue: 'Clientes',
          route: routes.listaClientes,
          hasSubRoute: false,
          showSubRoute: false,
          icon: 'user',
          page: 'customer-list',
          subMenus: []
        },
      ]
    },
    {
      tittle: 'Cuentas por Pagar',
      showAsTab: true,
      separateRoute: false,
      menu: [
        {
          menuValue: 'Proveedores',
          route: routes.listaPoveedores,
          hasSubRoute: false,
          showSubRoute: false,
          icon: 'user',
          page: 'customer-list',
          subMenus: []
        },
      ]
    },
    {
      tittle: 'Productos',
      showAsTab: true,
      separateRoute: false,
      menu: [
        {
          menuValue: 'lista de Productos',
          route: routes.listaProducto,
          hasSubRoute: false,
          showSubRoute: false,
          icon: 'shopping-bag',
          page: 'lista-producto',
          subMenus: []
        },
        // {
        //   menuValue: 'Crear Producto',
        //   route: routes.addProduct,
        //   hasSubRoute: false,
        //   showSubRoute: false,
        //   icon: 'plus-square',
        //   page: 'add-product',
        //   subMenus: []
        // },
        // {
        //   menuValue: 'Importar Productos',
        //   route: routes.importProduct,
        //   hasSubRoute: false,
        //   showSubRoute: false,
        //   icon: 'minimize-2',
        //   page: 'import-product',
        //   subMenus: []
        // },
      ]
    },
    // {
    //   tittle: 'Purchases',
    //   showAsTab: true,
    //   separateRoute: false,
    //   menu: [
    //     {
    //       menuValue: 'Purchases',
    //       route: routes.purchaseList,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'shopping-bag',
    //       page: 'purchase-list',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Import Purchases',
    //       route: routes.importPurchase,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'minimize-2',
    //       page: 'import-purchase',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Purchase Order',
    //       route: routes.purchaseOrderReport,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'file-minus',
    //       page: 'purchase-order-report',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Purchase Return',
    //       route: routes.purchaseReturnList,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'refresh-cw',
    //       page: 'purchase-return-list',
    //       subMenus: []
    //     },
    //   ]
    // },
    // {
    //   tittle: 'Finance & Accounts',
    //   showAsTab: true,
    //   separateRoute: false,
    //   menu: [
    //     {
    //       menuValue: 'Expense',
    //       route: routes.expense,
    //       hasSubRoute: true,
    //       showSubRoute: false,
    //       icon: 'file-text',
    //       base: 'expense',
    //       subMenus: [
    //         {
    //           menuValue: 'Expenses',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.expenseList,
    //           page: 'expense-list',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Expense Category',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.expenseCategory,
    //           page: 'expense-category',
    //           subRoutes: [],
    //         },
    //       ],
    //     },
    //   ]
    // },
    // {
    //   tittle: 'Peoples',
    //   showAsTab: true,
    //   separateRoute: false,
    //   menu: [
    //     {
    //       menuValue: 'Customers',
    //       route: routes.customerList,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'user',
    //       page: 'customer-list',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Suppliers',
    //       route: routes.supplierList,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'users',
    //       page: 'supplier-list',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Users',
    //       route: routes.userList,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'user-check',
    //       page: 'user-list',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Stores',
    //       route: routes.storeList,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'home',
    //       page: 'store-list',
    //       subMenus: []
    //     },
    //   ]
    // },
    // {
    //   tittle: 'Reports',
    //   showAsTab: true,
    //   separateRoute: false,
    //   menu: [
    //     {
    //       menuValue: 'Sales Report',
    //       route: routes.salesReport,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'bar-chart-2',
    //       page: 'sales-report',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Purchase Report',
    //       route: routes.purchaseReport,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'pie-chart',
    //       page: 'purchase-report',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Inventory Report',
    //       route: routes.inventoryReport,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'credit-card',
    //       page: 'inventory-report',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Invoice Report',
    //       route: routes.invoiceReport,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'file',
    //       page: 'invoice-report',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Purchase Report',
    //       route: routes.purchaseOrderReport,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'bar-chart',
    //       page: 'purchase-order-report',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Supplier Report',
    //       route: routes.supplierReport,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'database',
    //       page: 'supplier-report',
    //       subMenus: []
    //     },
    //     {
    //       menuValue: 'Customer Report',
    //       route: routes.customerReport,
    //       hasSubRoute: false,
    //       showSubRoute: false,
    //       icon: 'pie-chart',
    //       page: 'customer-report',
    //       subMenus: []
    //     },
    //   ]
    // },
    // {
    //   tittle: 'User Management',
    //   showAsTab: true,
    //   separateRoute: false,
    //   menu: [
    //     {
    //       menuValue: 'Manage Users',
    //       route: routes.users,
    //       hasSubRoute: true,
    //       showSubRoute: false,
    //       icon: 'users',
    //       base: 'users',
    //       subMenus: [
    //         {
    //           menuValue: 'New User',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.newUser,
    //           page: 'new-user',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Users List',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.usersUserList,
    //           page: 'user-lists',
    //           subRoutes: [],
    //         },
    //       ],
    //     },
    //   ]
    // },
    // {
    //   tittle: 'Pages',
    //   showAsTab: true,
    //   separateRoute: false,
    //   menu: [
    //     {
    //       menuValue: 'Authentication',
    //       route: routes.auth,
    //       hasSubRoute: true,
    //       showSubRoute: false,
    //       icon: 'shield',
    //       base: 'auth',
    //       subMenus: [
    //         {
    //           menuValue: 'Login',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.signIn,
    //           page: '',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Register',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.signUp,
    //           page: '',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Forgot Password',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.forgotPassword,
    //           page: '',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Reset Password',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.forgotPassword,
    //           page: '',
    //           subRoutes: [],
    //         },
    //       ],
    //     },
    //     {
    //       menuValue: 'Error Pages',
    //       hasSubRoute: true,
    //       showSubRoute: false,
    //       icon: 'file-minus',
    //       route: routes.errorPages,
    //       base: '',
    //       subMenus: [
    //         {
    //           menuValue: '404 Error',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.errorPage404,
    //           page: '',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: '500 Error',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.errorPage500,
    //           page: '',
    //           subRoutes: [],
    //         },
    //       ],
    //     },
    //     {
    //       menuValue: 'Places',
    //       hasSubRoute: true,
    //       icon: 'map',
    //       showSubRoute: false,
    //       route: routes.places,
    //       base: 'places',
    //       subMenus: [
    //         {
    //           menuValue: 'Countries',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.countriesList,
    //           page: 'countries-list',
    //           subMenus: [],
    //         },
    //         {
    //           menuValue: 'States',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.stateList,
    //           page: 'state-list',
    //           subMenus: [],
    //         },
    //       ],
    //     },
    //     {
    //       menuValue: 'Blank Page',
    //       hasSubRoute: false,
    //       icon: 'file',
    //       showSubRoute: false,
    //       route: routes.blankPage,
    //       page: 'blank-page',
    //       subMenus: [],
    //     },
    //     {
    //       menuValue: 'Components',
    //       hasSubRoute: false,
    //       icon: 'hard-drive',
    //       showSubRoute: false,
    //       route: routes.components,
    //       page: 'components',
    //       subMenus: [],
    //     },
    //   ]
    // },
    // {
    //   tittle: 'UI Interface',
    //   showAsTab: true,
    //   separateRoute: false,
    //   menu: [
    //     {
    //       menuValue: 'Elements',
    //       hasSubRoute: true,
    //       icon: 'layers',
    //       showSubRoute: false,
    //       route: routes.element,
    //       base: 'element',
    //       subMenus: [
    //         {
    //           menuValue: 'Sweet Alerts',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.sweetAlerts,
    //           page: 'sweet-alerts',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Tooltip',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.tooltip,
    //           page: 'tooltip',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Popover',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.popover,
    //           page: 'popover',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Ribbon',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.ribbon,
    //           page: 'ribbon',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Clipboard',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.clipboard,
    //           page: 'clipboard',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Drag & Drop',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.dragDrop,
    //           page: 'drag-drop',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Range Slider',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.rangeSlider,
    //           page: 'range-slider',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Rating',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.rating,
    //           page: 'rating',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Toaster',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.toaster,
    //           page: 'toaster',
    //           subRoutes: [],
    //         },

    //         {
    //           menuValue: 'Text Editor',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.textEditor,
    //           page: 'text-editor',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Counter',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.counter,
    //           page: 'counter',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Scrollbar',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.scrollbar,
    //           page: 'scrollbar',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Spinner',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.spinner,
    //           page: 'spinner',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Notification',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.notification,
    //           page: 'notification',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Lightbox',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.lightbox,
    //           page: 'lightbox',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Timeline',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.timeline,
    //           page: 'timeline',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Form Wizard',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.formWizard,
    //           page: 'form-wizard',
    //           subRoutes: [],
    //         },
    //       ],
    //     },
    //     {
    //       menuValue: 'Charts',
    //       hasSubRoute: true,
    //       icon: 'bar-chart-2',
    //       showSubRoute: false,
    //       route: routes.charts,
    //       base: 'charts',
    //       subMenus: [
    //         {
    //           menuValue: 'Apex Charts',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.chartApex,
    //           page: 'chart-apex',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Ng2 Charts',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.chartNg2,
    //           page: 'chart-ng2',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Prime NG Charts',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.chartPrime,
    //           page: 'prime-ng',
    //           subRoutes: [],
    //         },
    //       ],
    //     },

    //     {
    //       menuValue: 'Icons',
    //       hasSubRoute: true,
    //       icon: 'database',
    //       showSubRoute: false,
    //       route: routes.icons,
    //       base: 'icons',
    //       subMenus: [
    //         {
    //           menuValue: 'Fontawesome Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconFontAwesome,
    //           page: 'icon-fontawesome',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Feather Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconFeather,
    //           page: 'icon-feather',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Ionic Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconIonic,
    //           page: 'icon-ionic',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Material Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconMaterial,
    //           page: 'icon-material',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Pe7 Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconPe7,
    //           page: 'icon-pe7',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Simpleline Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconSimpleline,
    //           page: 'icon-simpleline',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Themify Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconThemify,
    //           page: 'icon-themify',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Weather Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconWeather,
    //           page: 'icon-weather',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Typicon Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconTypicon,
    //           page: 'icon-typicon',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Flag Icons',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.iconFlag,
    //           page: 'icon-flag',
    //           subRoutes: [],
    //         },
    //       ],
    //     },

    //     {
    //       menuValue: 'Forms',
    //       hasSubRoute: true,
    //       icon: 'edit',
    //       showSubRoute: false,
    //       route: routes.forms,
    //       base: 'forms',
    //       subMenus: [
    //         {
    //           menuValue: 'Basic Inputs',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.formBasicInputs,
    //           page: 'form-basic-inputs',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Input Groups',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.formInputsGroups,
    //           page: 'form-input-groups',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Horizontal Form',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.formHorizontal,
    //           page: 'form-horizontal',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Vertical Form',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.formVertical,
    //           page: 'form-vertical',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Form Mask',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.formMask,
    //           page: 'form-mask',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Form Validation',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.formValidation,
    //           page: 'form-validation',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Form Select',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.formSelect,
    //           page: 'form-select',
    //           subRoutes: [],
    //         },
    //       ],
    //     },

    //     {
    //       menuValue: 'Table',
    //       hasSubRoute: true,
    //       icon: 'user',
    //       showSubRoute: false,
    //       route: routes.table,
    //       base: 'table',
    //       subMenus: [
    //         {
    //           menuValue: 'Basic Tables',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.basicTable,
    //           page: 'tables-basic',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Data Tables',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.dataTable,
    //           page: 'data-basic',
    //           subRoutes: [],
    //         },
    //       ],
    //     },
    //   ]
    // },
    // {
    //   tittle: 'Settings',
    //   showAsTab: true,
    //   separateRoute: false,
    //   menu: [
    //     {
    //       menuValue: 'Settings',
    //       hasSubRoute: true,
    //       icon: 'settings',
    //       showSubRoute: false,
    //       route: routes.settings,
    //       base: 'settings',
    //       subMenus: [
    //         {
    //           menuValue: 'General Settings',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.generalSettings,
    //           page: 'general-settings',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Email Settings',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.emailSettings,
    //           page: 'email-settings',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Payment Settings',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.paymentSettings,
    //           page: 'payment-settings',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Currency Settings',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.currencySettings,
    //           page: 'currency-settings',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Group Permissions',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.groupSettings,
    //           page: 'group-permissions',
    //           subRoutes: [],
    //         },
    //         {
    //           menuValue: 'Tax Rates',
    //           hasSubRoute: false,
    //           icon: '',
    //           showSubRoute: false,
    //           route: routes.taxRates,
    //           page: 'tax-rates',
    //           subRoutes: [],
    //         },
    //       ],
    //     },
    //     {
    //       menuValue: 'Logout',
    //       hasSubRoute: false,
    //       icon: 'log-out',
    //       showSubRoute: false,
    //       route: routes.signIn,
    //       subMenus: []
    //     }
    //   ]
    // },
  ]
  public getSideBarDataone: BehaviorSubject<Array<any>> = new BehaviorSubject<Array<any>>(this.sidebarDataone)
}
