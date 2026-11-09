import type {
  ServiceDto,
  AreaDto,
  ReviewDto,
  FAQDto,
  ProjectDto,
  CreateContactRequestCommand,
} from '../types';

// آدرس پیش‌فرض بک‌اند دات‌نت (قابل بازنویسی با فایل .env در صورت نیاز)
const API_BASE_URL = 'https://localhost:7273/api';
async function request<T>(endpoint: string, options?: RequestInit): Promise<T> {
  const response = await fetch(`${API_BASE_URL}${endpoint}`, {
    headers: {
      'Content-Type': 'application/json',
      ...options?.headers,
    },
    ...options,
  });

  if (!response.ok) {
    throw new Error(`API Error: ${response.status} ${response.statusText}`);
  }

  return response.json();
}

export const api = {
  // سرویس‌ها
  getServices: () => request<ServiceDto[]>('/services'),
  getServiceBySlug: (slug: string) => request<ServiceDto>(`/services/${slug}`),

  // مناطق تحت پوشش در منچستر
  getAreas: () => request<AreaDto[]>('/areas'),
  getAreaBySlug: (slug: string) => request<AreaDto>(`/areas/${slug}`),

  // نظرات مشتریان
  getReviews: () => request<ReviewDto[]>('/reviews'),

  // سوالات متداول
  getFaqs: () => request<FAQDto[]>('/faqs'),

  // پروژه‌ها و نمونه‌کارها
  getProjects: () => request<ProjectDto[]>('/projects'),

  // فرم ثبت تماس (POST)
  createContactRequest: (command: CreateContactRequestCommand) =>
    request<{ id: string }>('/contact-requests', {
      method: 'POST',
      body: JSON.stringify(command),
    }),
};
