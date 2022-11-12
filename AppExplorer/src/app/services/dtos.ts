export interface AppDetailsDto {
    id: number;
    name: string;
    appInfo: AppInfoDto;
    languages: LanguageDto[];
    appUrls: AppUrlsDto;
    category: CategoryDto;
    createdDate: string;
    updatedDate: string;
}

export interface AppInfoDto {
    shortDescription: string;
    description: string;
    imagePath: string;
}

export interface AppUrlsDto {
    sourceUrl: string;
    productUrl: string;
    libUrl: string;
    downloadUrl: string;
    articleUrl: string;
}

export interface AppDto {
    id: number;
    name: string;
    shortDescription: string;
    imagePath: string;
}

export interface CategoryDto {
    id: number;
    name: string;
}

export interface LanguageDto {
    id: number;
    name: string;
}