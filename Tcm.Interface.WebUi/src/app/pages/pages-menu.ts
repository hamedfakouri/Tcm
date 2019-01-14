import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'داشبورد',
    icon: 'nb-home',
    link: '/',
    home: true,
  },
  {
    title: 'FEATURES',
    group: true,
  },
  {
    title: 'اطلاعات پایه',
    icon: 'nb-star',
    children: [
      {
        title: 'دوره تحصیلی',
        link: '/Baseinfo/calendar',
      },
      {
        title: 'مقطع تحصیلی',
        link: '/pages/extra-components/stepper',
      },
      {
        title: 'پایه تحصیلی',
        link: '/pages/extra-components/list',
      },
    ],
  },
  {
    title: 'کاربر',
    icon: 'nb-keypad',
    children: [
      {
        title: 'ورود',
        link: '/Auth/Login',
      },
      {
        title: 'ثبت نام',
        link: '/Auth/Register',
      }
    ],
  }
];
