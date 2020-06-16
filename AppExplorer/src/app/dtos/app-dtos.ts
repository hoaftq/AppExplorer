export interface AppDto {
    id: number;
    name: string;
    shortDescription: string;
    imagePath?: string;
}

export interface AppDetailsDto {
    id: number;
    name: string;
    shortDescription: string;
    description: string;
    imagePath?: string;
    language: string;
    level: number;
    url?: string;
    sourceUrl: string;
    createdDate: Date;
    updatedDate: Date;

    categoryId: number;
    categoryName: string;
}

export interface CategoryDto {
    id: number;
    name: string;
}