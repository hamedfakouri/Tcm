import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'داشبورد',
    icon: 'nb-home',
    link: '/',
    home: true,
  },
  {
    title: 'شناسنامه مدارس',
    icon: 'nb-layout-sidebar-right',
    link: 'School',
  },
  {
    title: 'مدیریت کلاس',
    icon: 'nb-compose',
    children: [
      {
        title: 'کلاس آموزشی',
        link: 'ClassRoom',
      },
    ]
  },
  {
    title: 'اطلاعات پایه',
    icon: 'nb-edit',
    children: [
      {
        title: 'سال تحصیلی',
        link: 'educationYear',
      },
      {
        title: 'مقطع تحصیلی',
        link: 'educationLevel',
      },
      {
        title: 'دوره تحصیلی',
        link: 'EducationCourse',
      },
      {
        title: 'پایه تحصیلی',
        link: 'EducationSubCourse',
      },
      {
        title: 'رشته تحصیلی',
        link: 'Major',
      },
      {
        title: 'نوع مدرسه',
        link: 'SchoolType',
      },
      {
        title: 'دسته بندی مدارس',
        link: 'SchoolSubType',
      },
    ],
  },
  {
    title: 'کاربر',
    icon: 'nb-person',
    children: [
      {
        title: 'مدیر مدرسه',
        link: '/account/register/1',
      },
      {
        title: 'ایجاد دانش آموز',
        link: '/account/register/2',
      },
      {
        title: 'ایجاد پرسنل',
        link: '/account/register'
      }
    ],
  }
];
