
// منطبق با ReviewStatus در بک‌اند (Pending=1, Published=2, Rejected=3)
export const ReviewStatus = {
  Pending: 1,
  Published: 2,
  Rejected: 3,
} as const;

export type ReviewStatus = (typeof ReviewStatus)[keyof typeof ReviewStatus];

export interface ReviewDto {
  id: string;
  customerName: string;
  content: string;
  rating: number;
  status: ReviewStatus;
}

export interface ServiceDto {
  id: string;
  title: string;
  slug: string;
  shortDescription: string;
  description: string;
  imageUrl?: string | null;
  isEmergency: boolean;
  displayOrder: number;
}

export interface AreaDto {
  id: string;
  name: string;
  slug: string;
  shortDescription: string;
  description: string;
  displayOrder: number;
}

export interface FAQDto {
  id: string;
  question: string;
  answer: string;
  displayOrder: number;
}

export interface ProjectDto {
  id: string;
  title: string;
  description: string;
  imageUrl?: string | null;
  location: string;
}

// مطابق با CreateContactRequestCommand در بک‌اند
export interface CreateContactRequestCommand {
  name: string;
  email: string;
  phone: string;
  message?: string | null;
}
