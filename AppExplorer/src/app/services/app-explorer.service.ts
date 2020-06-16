import { Injectable } from '@angular/core';
import { AppDetailsDto, AppDto, CategoryDto } from '../dtos/app-dtos';

@Injectable({
  providedIn: 'root'
})
export class AppExplorerService {

  private apps = [
    {
      id: 1,
      name: 'TicTacToe',
      shortDescription: 'TicTacToe game with 3x3 board',
      description: '',
      imagePath: 'assets/TicTacToe.jpg',
      language: 'Javascript',
      level: 1,
      url: 'https://blue-coast-08ba4c600.azurestaticapps.net/',
      sourceUrl: 'https://github.com/hoaftq/TicTacToe',
      createdDate: new Date(),
      updatedDate: new Date(),

      categoryId: 1,
      categoryName: 'Game'
    },
    {
      id: 2,
      name: '248Game',
      shortDescription: '248 Game',
      description: '',
      imagePath: 'assets/248Game.jpg',
      language: 'Javascript',
      level: 2,
      url: 'https://zealous-ocean-06d94d200.azurestaticapps.net/',
      sourceUrl: 'https://github.com/hoaftq/248Game',
      createdDate: new Date(),
      updatedDate: new Date(),

      categoryId: 1,
      categoryName: 'Game'
    },
    {
      id: 3,
      name: 'Test data generator',
      shortDescription: 'A tool to generate test data',
      description: '',
      language: 'C#',
      level: 1,
      url: 'https://zealous-ocean-06d94d200.azurestaticapps.net/',
      sourceUrl: 'https://github.com/hoaftq/248Game',
      createdDate: new Date(),
      updatedDate: new Date(),

      categoryId: 2,
      categoryName: 'Tool'
    },
    {
      id: 4,
      name: 'Sudoku',
      shortDescription: 'A popular puzzle game',
      description: '',
      language: 'C#',
      level: 3,
      url: 'https://zealous-ocean-06d94d200.azurestaticapps.net/',
      sourceUrl: 'https://github.com/hoaftq/248Game',
      createdDate: new Date(),
      updatedDate: new Date(),

      categoryId: 1,
      categoryName: 'Game'
    }
  ];

  constructor() { }

  getApps(): AppDto[] {
    return this.apps.map(e => ({
      id: e.id,
      name: e.name,
      imagePath: e.imagePath,
      shortDescription: e.shortDescription
    }));
  }

  getAppDetails(id: number): AppDetailsDto {
    return this.apps.find(e => e.id == id);
  }

  getBestApps(numberOfApps: number = 3): AppDto[] {
    return this.apps.sort(e => e.level).slice(0, numberOfApps).map(e => ({
      id: e.id,
      name: e.name,
      imagePath: e.imagePath,
      shortDescription: e.shortDescription
    }));
  }

  getCategories(): CategoryDto[] {
    return [
      { id: 1, name: 'Game' },
      { id: 2, name: "Tool" }
    ];
  }
}
