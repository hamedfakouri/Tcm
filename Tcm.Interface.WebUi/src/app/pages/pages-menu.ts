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
        link: '/BaseInfo/EducationCourse',
      },
      {
        title: 'مقطع تحصیلی',
        link: 'educationLevel/list',
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
        title: 'مدیر مدرسه',
        link: '/User/Manager',
      },
      {
        title: 'دانش آموز',
        link: '/User/Student',
      },
      {
        title: 'پرسنل مدرسه',
        link: '/Student/Personnel'        
      }
    ],
  }
];
