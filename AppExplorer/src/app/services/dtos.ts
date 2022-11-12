export interface App extends Entity {
    name: string;
    appInfo: AppInfo;
    appUrls: AppUrls;
    category: Category;
    languages: Language[];
}

export interface AppInfo {
    shortDescription: string;
    description: string;
    imagePath: string;
}

export interface AppUrls {
    sourceUrl: string;
    productUrl: string;
    libUrl: string;
    downloadUrl: string;
    articleUrl: string;
}

export interface Category extends Entity {
    name: string;
}

export interface Language extends Entity {
    name: string;
    apps: App[];
}

export interface Entity {
    id: number;
    createdDate: string;
    updatedDate: string;
}